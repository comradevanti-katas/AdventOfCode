use std::env;
use std::fs;
use std::io;

use parse::Input;

mod parse;
mod types;
mod verification;

fn solve_for(s: &str) -> u32 {
    let input = Input::from_str(&s);

    let ok_updates = input
        .1
        .iter()
        .filter(|update| input.0.iter().all(|rule| rule.verify(update)));

    let mid_values = ok_updates.map(|update| update.mid_value());

    mid_values.map(|it| *it as u32).sum()
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let text = fs::read_to_string(file_path)?;
    let sum = solve_for(&text);

    println!("The sum is {sum}.");

    Ok(())
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_solve_example() {
        let input = "47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47
";

        let actual = solve_for(&input);
        assert_eq!(actual, 143)
    }
}
