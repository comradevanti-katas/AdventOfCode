use std::env;
use std::fs;
use std::io;

mod search;

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let lines = text.lines();
    let chars: Vec<Vec<char>> = lines.map(|line| line.chars().collect()).collect();
    let count = search::text_in_matrix(&chars, "XMAS");

    println!("There are {count} instances of XMAS");

    Ok(())
}
