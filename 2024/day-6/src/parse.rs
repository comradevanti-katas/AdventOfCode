use std::str::FromStr;

use crate::types::*;

fn walls_in_line<'a>(line: &'a str) -> impl Iterator<Item = Coord> + 'a {
    line.chars()
        .enumerate()
        .filter(|(_, c)| *c == '#')
        .map(|(i, _)| i as Coord)
}

fn walls_in_block<'a>(block: &'a str) -> impl Iterator<Item = Pos> + 'a {
    block
        .lines()
        .enumerate()
        .flat_map(move |(y, line)| walls_in_line(&line).map(move |x| (x, y as Coord)))
}

fn find_guard(block: &str) -> Guard {
    block
        .lines()
        .enumerate()
        .filter_map(|(y, line)| {
            line.chars().position(|c| c == '^').map(|x| Guard {
                pos: (x as Coord, y as Coord),
                dir: Dir::Up,
            })
        })
        .next()
        .expect("Should find one guard")
}

impl FromStr for Map {
    type Err = ();

    fn from_str(block: &str) -> Result<Self, Self::Err> {
        let height = block.lines().count();
        let width = block
            .lines()
            .next()
            .expect("Must have at least one line")
            .len();

        Ok(Map {
            width,
            height,
            walls: walls_in_block(&block).collect(),
        })
    }
}

impl FromStr for Input {
    type Err = ();

    fn from_str(block: &str) -> Result<Self, Self::Err> {
        Ok(Input {
            map: block.parse().expect("Must parse"),
            guard: find_guard(&block),
        })
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;

    #[rstest]
    #[case("..........", vec![])]
    #[case("....#.....", vec![4])]
    #[case("..#......#", vec![2,9])]
    #[case(".#..^.....", vec![1])]
    fn should_find_walls_in_line(#[case] s: &str, #[case] expected: Vec<Coord>) {
        let actual: Vec<Coord> = walls_in_line(&s).collect();
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("....#.....\n.........#", vec![(4,0),(9,1)])]
    #[case(".......#..\n..........\n.#..^.....", vec![(7,0),(1,2)])]
    fn should_find_walls_in_block(#[case] s: &str, #[case] expected: Vec<Pos>) {
        let actual: Vec<Pos> = walls_in_block(&s).collect();
        assert_eq!(actual, expected)
    }

    #[test]
    fn should_find_guard() {
        let input = "....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

        let expected = Guard {
            pos: (4, 6),
            dir: Dir::Up,
        };
        let actual = find_guard(&input);
        assert_eq!(actual, expected);
    }

    #[test]
    fn should_parse_input() {
        let input = "....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

        let expected = Input {
            map: Map {
                height: 10,
                width: 10,
                walls: vec![
                    (4, 0),
                    (9, 1),
                    (2, 3),
                    (7, 4),
                    (1, 6),
                    (8, 7),
                    (0, 8),
                    (6, 9),
                ],
            },
            guard: Guard {
                pos: (4, 6),
                dir: Dir::Up,
            },
        };
        let actual: Input = input.parse().expect("Should parse");
        assert_eq!(actual, expected);
    }
}
