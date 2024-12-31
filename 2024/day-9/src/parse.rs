use std::{num::ParseIntError, str::FromStr};

use crate::domain::*;

type DiskMapParseError = ParseIntError;

impl FromStr for DiskMap {
    type Err = DiskMapParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let disk_map = s
            .trim_end()
            .chars()
            .map(|c| c.to_string().parse())
            .collect::<Result<_, Self::Err>>()?;

        Ok(DiskMap(disk_map))
    }
}

type FsParseError = ParseIntError;

impl FromStr for Fs {
    type Err = FsParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let blocks = s
            .chars()
            .map(|c| match c {
                '.' => FsBlock::Empty,
                _ => FsBlock::File(c.to_string().parse().expect("should be number")),
            })
            .collect();
        Ok(Fs { blocks })
    }
}

type InputParseError = DiskMapParseError;

impl FromStr for Input {
    type Err = InputParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let disk_map = s.parse()?;
        Ok(Input(disk_map))
    }
}

#[cfg(test)]
mod tests {

    use super::*;

    #[test]
    fn should_parse_disk_map() {
        let input = "2333133121414131402";
        let expected = DiskMap(vec![
            2, 3, 3, 3, 1, 3, 3, 1, 2, 1, 4, 1, 4, 1, 3, 1, 4, 0, 2,
        ]);

        let actual: DiskMap = input.parse().expect("Should parse");

        assert_eq!(actual, expected)
    }

    #[test]
    fn should_parse_fs() {
        let input = "0..111....22222";
        let expected = Fs::from_blocks(vec![
            (FsBlock::File(0), 1),
            (FsBlock::Empty, 2),
            (FsBlock::File(1), 3),
            (FsBlock::Empty, 4),
            (FsBlock::File(2), 5),
        ]);
        let actual: Fs = input.parse().expect("should parse");
        assert_eq!(actual, expected)
    }
}
