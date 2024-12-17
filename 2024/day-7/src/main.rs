use crate::domain::*;
use std::env;
use std::fs;
use std::io;

mod domain;
mod parse;

fn solve_for(s: &str) -> u64 {
    let input: Input = s.parse().expect("Should parse");
    let true_equations = input.0.iter().filter(|eq| can_be_true(&eq));
    true_equations.map(|eq| eq.result).sum()
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let visited_count = solve_for(&text);

    println!("The total sum is {visited_count}.");

    Ok(())
}
