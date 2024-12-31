use std::iter;

pub type FileId = usize;

#[derive(PartialEq, Debug, Clone)]
pub struct DiskMap(pub Vec<u8>);

#[derive(PartialEq, Debug, Clone, Copy)]
pub enum FsBlock {
    Empty,
    File(FileId),
}

#[derive(PartialEq, Debug, Clone)]
pub struct Fs {
    pub blocks: Vec<FsBlock>,
}

impl Fs {
    pub fn new() -> Self {
        Self { blocks: vec![] }
    }

    pub fn from_blocks(block_counts: Vec<(FsBlock, usize)>) -> Self {
        let blocks = block_counts
            .iter()
            .flat_map(|(block, count)| iter::repeat(*block).take(*count).into_iter())
            .collect();
        Self { blocks }
    }

    fn append_empty(&mut self, count: usize) {
        for _ in 0..count {
            self.blocks.push(FsBlock::Empty);
        }
    }

    fn next_file_id(&self) -> usize {
        self.blocks
            .iter()
            .rev()
            .find_map(|&it| match it {
                FsBlock::Empty => None,
                FsBlock::File(id) => Some(id + 1),
            })
            .unwrap_or(0)
    }

    fn append_file(&mut self, count: usize) {
        let file = FsBlock::File(self.next_file_id());
        for _ in 0..count {
            self.blocks.push(file);
        }
    }

    pub fn from_disk_map(disk_map: &DiskMap) -> Self {
        let mut fs = Fs::new();

        for (i, &count) in disk_map.0.iter().enumerate() {
            if i % 2 == 0 {
                fs.append_file(count as usize);
            } else {
                fs.append_empty(count as usize);
            }
        }

        fs
    }

    fn first_gap(&self) -> Option<usize> {
        self.blocks
            .iter()
            .enumerate()
            .find_map(|(i, &block)| match block {
                FsBlock::Empty => Some(i),
                _ => None,
            })
    }

    fn last_file(&self) -> Option<usize> {
        self.blocks
            .iter()
            .enumerate()
            .rev()
            .find_map(|(i, &block)| match block {
                FsBlock::File(_) => Some(i),
                _ => None,
            })
    }

    pub fn compact_once(&mut self) {
        match (self.first_gap(), self.last_file()) {
            (Some(first_gap), Some(last_file)) => {
                self.blocks.swap(first_gap, last_file);
            }
            _ => {}
        }
    }

    pub fn compact_fully(&mut self) {
        if self.is_compact() {
            return;
        }
        self.compact_once();
        self.compact_fully();
    }

    pub fn is_compact(&self) -> bool {
        match (self.first_gap(), self.last_file()) {
            (Some(first_gap), Some(last_file)) => first_gap > last_file,
            _ => true,
        }
    }

    pub fn checksum(&self) -> usize {
        self.blocks
            .iter()
            .enumerate()
            .filter_map(|(i, &block)| match block {
                FsBlock::Empty => None,
                FsBlock::File(file_id) => Some((i, file_id)),
            })
            .map(|(i, file_id)| i * file_id)
            .sum()
    }
}

pub struct Input(pub DiskMap);

#[cfg(test)]
mod tests {

    use rstest::rstest;

    use super::*;

    #[test]
    fn should_make_fs_from_disk_map() {
        let disk_map: DiskMap = "2333133121414131402".parse().unwrap();
        let expected: Fs = "00...111...2...333.44.5555.6666.777.888899"
            .parse()
            .unwrap();

        let actual = Fs::from_disk_map(&disk_map);
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("0..111....22222", "02.111....2222.")]
    #[case("02211122..2....", "022111222......")]
    #[case(
        "00998111...2...333.44.5555.6666.777.888...",
        "009981118..2...333.44.5555.6666.777.88...."
    )]
    #[case(
        "00998111888277733364465555.66.............",
        "0099811188827773336446555566.............."
    )]
    fn should_compact_correctly(#[case] mut actual: Fs, #[case] expected: Fs) {
        actual.compact_once();
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("0221112...22...", false)]
    #[case("022111222......", true)]
    #[case("009981118..2...333.44.5555.6666.777.88....", false)]
    #[case("0099811188827773336446555566..............", true)]
    fn should_correctly_classify_fs_as_compact(#[case] fs: Fs, #[case] expected: bool) {
        assert_eq!(fs.is_compact(), expected)
    }

    #[test]
    fn should_calculate_correct_checksum() {
        let fs: Fs = "0099811188827773336446555566.............."
            .parse()
            .expect("Should parse");
        assert_eq!(fs.checksum(), 1928)
    }
}
