use std::str::FromStr;

use crate::domain::*;

#[derive(Debug)]
pub enum MapParseError {
    ZeroHeight,
}

impl FromStr for Map {
    type Err = MapParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let chars: Vec<Vec<char>> = s.lines().map(|line| line.chars().collect()).collect();
        let height = chars.len();

        if height == 0 {
            return Err(MapParseError::ZeroHeight);
        }

        let width = chars[0].len();

        let mut map = Map::empty(width, height);

        for y in 0..height {
            for x in 0..width {
                let char = chars[y][x];

                if char == '.' {
                    continue;
                }

                map = map.add_antenna(&Pos::new(x as isize, y as isize), char);
            }
        }

        Ok(map)
    }
}

type InputParseError = MapParseError;

impl FromStr for Input {
    type Err = InputParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let map = s.parse()?;
        Ok(Input { map })
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;

    #[test]
    fn should_parse_map() {
        let input = "............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............";

        let expected = Map::empty(12, 12)
            .add_antenna(&Pos::new(8, 1), '0')
            .add_antenna(&Pos::new(5, 2), '0')
            .add_antenna(&Pos::new(7, 3), '0')
            .add_antenna(&Pos::new(4, 4), '0')
            .add_antenna(&Pos::new(6, 5), 'A')
            .add_antenna(&Pos::new(8, 8), 'A')
            .add_antenna(&Pos::new(9, 9), 'A');

        let actual: Map = input.parse().expect("Should parse");

        assert_eq!(actual, expected)
    }
}
