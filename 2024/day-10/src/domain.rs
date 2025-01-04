use std::{collections::HashSet, hash::Hash};

#[derive(Debug, PartialEq, Clone, Eq, Hash)]
pub struct Pos {
    pub x: isize,
    pub y: isize,
}

impl Pos {
    pub fn above(&self) -> Pos {
        Pos {
            x: self.x,
            y: self.y - 1,
        }
    }

    pub fn right(&self) -> Pos {
        Pos {
            x: self.x + 1,
            y: self.y,
        }
    }

    pub fn below(&self) -> Pos {
        Pos {
            x: self.x,
            y: self.y + 1,
        }
    }

    pub fn left(&self) -> Pos {
        Pos {
            x: self.x - 1,
            y: self.y,
        }
    }
}

#[derive(Debug, PartialEq)]
pub struct Map {
    width: usize,
    height: usize,
    height_values: Vec<u8>,
}

impl Map {
    fn index_for(&self, pos: &Pos) -> Option<usize> {
        if pos.x < 0 || pos.y < 0 {
            return None;
        }

        let x = pos.x as usize;
        let y = pos.y as usize;

        if x >= self.width || y >= self.height {
            return None;
        }

        Some(y * self.width + x)
    }

    pub fn from_rows(rows: Vec<Vec<u8>>) -> Map {
        let height = rows.len();
        let width = rows[0].len();

        let height_values = rows.concat();

        Map {
            height,
            width,
            height_values,
        }
    }

    pub fn positions(&self) -> impl Iterator<Item = Pos> + '_ {
        (0..self.height).flat_map(move |y| {
            (0..self.width).map(move |x| Pos {
                x: x as isize,
                y: y as isize,
            })
        })
    }

    fn try_height_at(&self, pos: &Pos) -> Option<u8> {
        self.index_for(&pos).map(|i| self.height_values[i])
    }

    fn trail_ends_from(&self, pos: &Pos, expected_height: u8) -> HashSet<Pos> {
        let mut trail_ends = HashSet::new();
        if let Some(height) = self.try_height_at(&pos) {
            if height != expected_height {
            } else if height == 9 {
                trail_ends.insert(pos.clone());
            } else {
                let next_height = height + 1;
                trail_ends.extend(self.trail_ends_from(&pos.above(), next_height));
                trail_ends.extend(self.trail_ends_from(&pos.right(), next_height));
                trail_ends.extend(self.trail_ends_from(&pos.below(), next_height));
                trail_ends.extend(self.trail_ends_from(&pos.left(), next_height));
            }
        }
        trail_ends
    }

    pub fn count_trails_from(&self, trail_head: &Pos) -> usize {
        self.trail_ends_from(trail_head, 0).len()
    }
}

#[cfg(test)]
mod tests {
    use rstest::rstest;

    use super::*;

    #[rstest]
    #[case(Pos{x:2,y:0},5)]
    #[case(Pos{x:4,y:0},6)]
    #[case(Pos{x:4,y:2},5)]
    fn should_count_correct_trail_count(#[case] pos: Pos, #[case] expected: usize) {
        let map: Map = "89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732"
            .parse()
            .unwrap();

        let actual = map.count_trails_from(&pos);

        assert_eq!(actual, expected)
    }
}
