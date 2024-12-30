use core::num;
use std::str::FromStr;

use crate::domain::*;

type InputParseError = ();

impl FromStr for Input {
    type Err = InputParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let mut fs = Fs::new();

        let nums: Vec<usize> = s
            .chars()
            .map(|c| c.to_string().parse().expect("Must be number"))
            .collect();

        for (i, &count) in nums.iter().enumerate() {
            if i % 2 == 0 {
                fs.append_file(count);
            } else {
                fs.append_empty(count);
            }
        }

        Ok(Input(fs))
    }
}

#[cfg(test)]
mod tests {

    use super::*;

    #[test]
    fn should_parse() {
        let input = "2333133121414131402";
        // 00...111...2...333.44.5555.6666.777.888899
        let expected = Fs::from_blocks(vec![
            (FsBlock::File(0), 2),
            (FsBlock::Empty, 3),
            (FsBlock::File(1), 3),
            (FsBlock::Empty, 3),
            (FsBlock::File(2), 1),
            (FsBlock::Empty, 3),
            (FsBlock::File(3), 3),
            (FsBlock::Empty, 1),
            (FsBlock::File(4), 2),
            (FsBlock::Empty, 1),
            (FsBlock::File(5), 4),
            (FsBlock::Empty, 1),
            (FsBlock::File(6), 4),
            (FsBlock::Empty, 1),
            (FsBlock::File(7), 3),
            (FsBlock::Empty, 1),
            (FsBlock::File(8), 4),
            (FsBlock::File(9), 2),
        ]);

        let actual: Input = input.parse().expect("Should parse");

        assert_eq!(actual.0, expected)
    }
}
