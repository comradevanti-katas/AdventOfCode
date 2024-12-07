use std::env;
use std::fs;
use std::io;

use types::*;

mod map_query;
mod parse;
mod simulation;
mod types;

use itertools::Itertools;

fn trace_path<'a>(map: &'a Map, guard: &Guard) -> Vec<Pos> {
    if !map.contains_pos(&guard.pos) {
        return Vec::new();
    }

    let mut path = trace_path(map, &simulation::simulate_guard(map, &guard));
    path.insert(0, guard.pos);
    path
}

fn solve_for(s: &str) -> u32 {
    let input: Input = s.parse().expect("Should parse");
    let path = trace_path(&input.map, &input.guard);
    path.into_iter().unique().count() as u32
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let visited_count = solve_for(&text);

    println!("The guard visited {visited_count} tiles.");

    Ok(())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_solve_example() {
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

        let actual = solve_for(&input);
        assert_eq!(actual, 41)
    }
}
