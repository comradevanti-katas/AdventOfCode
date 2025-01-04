use std::str::FromStr;

use crate::domain::*;

#[derive(Debug, PartialEq)]
pub enum MapParseError {
    DigitParse,
}

impl FromStr for Map {
    type Err = MapParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let rows = s
            .lines()
            .map(|line| {
                line.chars()
                    .map(|c| {
                        c.to_digit(10)
                            .map(|i| i as u8)
                            .ok_or(MapParseError::DigitParse)
                    })
                    .collect::<Result<_, _>>()
            })
            .collect::<Result<_, _>>()?;

        Ok(Map::from_rows(rows))
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    pub fn should_parse_map() {
        let input = "0123
1234
8765
9876";

        let expected = Map::from_rows(vec![
            vec![0, 1, 2, 3],
            vec![1, 2, 3, 4],
            vec![8, 7, 6, 5],
            vec![9, 8, 7, 6],
        ]);

        let actual: Map = input.parse().unwrap();

        assert_eq!(actual, expected)
    }
}
