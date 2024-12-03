use std::env;
use std::fs;
use std::io;

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let input = text.lines();
    Ok(())
}
