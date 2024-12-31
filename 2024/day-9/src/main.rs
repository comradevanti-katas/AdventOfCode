use std::env;
use std::fs;
use std::io;

use domain::*;

mod domain;
mod parse;

fn solve_for(s: &str) -> usize {
    let disk_map: DiskMap = s.parse().unwrap();
    let mut fs = Fs::from_disk_map(&disk_map);
    fs.compact_fully();
    fs.checksum()
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
    fn should_solve_star_1() {
        let input = "2333133121414131402";
        let expected = 1928;

        let actual = solve_for(&input);

        assert_eq!(actual, expected)
    }
}
