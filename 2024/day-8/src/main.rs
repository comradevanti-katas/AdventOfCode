use std::collections::HashSet;
use std::env;
use std::fs;
use std::io;

use domain::Input;

mod domain;
mod parse;

fn solve_for(s: &str) -> usize {
    let input: Input = s.parse().expect("Should parse");
    let map = input.map;

    map.antennas()
        .flat_map(|&antenna| map.find_anti_nodes_for(antenna))
        .collect::<HashSet<_>>()
        .into_iter()
        .filter(|node| map.contains(node))
        .count()
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let output = solve_for(&text);

    println!("{}", output);
    Ok(())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_give_correct_output() {
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

        let actual = solve_for(&input);

        assert_eq!(actual, 14)
    }
}
