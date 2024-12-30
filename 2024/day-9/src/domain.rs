use std::{io::Empty, iter};

pub type FileId = usize;

#[derive(PartialEq, Debug, Clone, Copy)]
pub enum FsBlock {
    Empty,
    File(FileId),
}

#[derive(PartialEq, Debug, Clone)]
pub struct Fs {
    blocks: Vec<FsBlock>,
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

    pub fn append_empty(&mut self, count: usize) {
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

    pub fn append_file(&mut self, count: usize) {
        let file = FsBlock::File(self.next_file_id());
        for _ in 0..count {
            self.blocks.push(file);
        }
    }
}

pub struct Input(pub Fs);
