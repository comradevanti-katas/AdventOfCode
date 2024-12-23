use std::env;
use std::fs;
use std::io;

mod domain;
mod parse;

fn solve_for(s: &str) -> u64 {
    todo!()
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let output = solve_for(&text);

    println!("{}", output);
    Ok(())
}
