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
    let reports = input.map(|it| parse::report(it)).collect::<Vec<_>>();

    let strict_safe_count = reports
        .iter()
        .filter(|it| evaluate::is_strict_safe(it))
        .count();
    println!("There were {strict_safe_count} strictly safe lines");

    let loose_safe_count = reports
        .iter()
        .filter(|it| evaluate::is_loose_safe(it))
        .count();
    println!("There were {loose_safe_count} loosly safe lines");
    Ok(())
}
