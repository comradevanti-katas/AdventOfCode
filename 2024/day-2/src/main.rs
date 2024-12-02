mod evaluate;
mod parse;
use std::env;
use std::fs;
use std::io;

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let input = text.lines();
    let reports = input.map(|it| parse::report(it));
    let safe_count = reports.filter(|it| evaluate::is_safe(it)).count();

    println!("There were {safe_count} safe lines");

    Ok(())
}
