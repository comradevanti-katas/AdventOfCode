use std::env;
use std::fs;
use std::io;

mod evaluate;
mod parse;

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let muls = parse::mul(&text);
    let sum: u32 = muls.iter().map(|it| evaluate::evaluate_mul(it)).sum();

    println!("The total sum is {sum}.");

    Ok(())
}
