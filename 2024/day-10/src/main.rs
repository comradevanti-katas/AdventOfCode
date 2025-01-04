use std::env;
use std::fs;
use std::io;

use domain::*;

mod domain;
mod parse;

fn solve_for(s: &str) -> usize {
    let map: Map = s.parse().unwrap();
    map.positions().map(|pos| map.count_trails_from(&pos)).sum()
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
    pub fn should_solve_star_1() {
        let input = "89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732";

        let actual = solve_for(&input);

        assert_eq!(actual, 36)
    }
}
