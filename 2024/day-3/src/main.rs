use std::env;
use std::fs;
use std::sync::LazyLock;

use regex::Regex;

#[derive(PartialEq, Debug)]
enum Instr {
    Mul(u16, u16),
    Do,
    Dont,
}

static INSTR_REGEX: LazyLock<Regex> =
    LazyLock::new(|| Regex::new(r"(mul\((\d{1,3}),(\d{1,3})\))|(do\(\))|(don't\(\))").unwrap());

fn iter_instructions(memory: &str) -> impl Iterator<Item = Instr> + use<'_> {
    INSTR_REGEX.captures_iter(memory).map(|c| {
        if let (Some(a), Some(b)) = (c.get(2), c.get(3)) {
            Instr::Mul(a.as_str().parse().unwrap(), b.as_str().parse().unwrap())
        } else if c.get(4).is_some() {
            Instr::Do
        } else if c.get(5).is_some() {
            Instr::Dont
        } else {
            panic!("Bad capture")
        }
    })
}

fn eval_instructions(instructions: impl Iterator<Item = Instr>) -> u32 {
    let mut sum = 0;
    let mut eval = true;

    for instruction in instructions {
        match instruction {
            Instr::Mul(a, b) => {
                if eval {
                    sum += a as u32 * b as u32
                }
            }
            Instr::Do => eval = true,
            Instr::Dont => eval = false,
        }
    }

    sum
}

fn main() {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let memory = fs::read_to_string(file_path).expect("Input could not be read.");

    let mul_instructions = iter_instructions(&memory).filter(|it| matches!(it, Instr::Mul(_, _)));
    let mul_result = eval_instructions(mul_instructions);
    println!("The result of the filtered program is {}", mul_result);

    let all_instructions = iter_instructions(&memory);
    let full_result = eval_instructions(all_instructions);
    println!("The result of the full program is {}", full_result);
}

#[cfg(test)]
mod test {
    use crate::*;

    #[test]
    fn should_extract_correct_mul_instructions() {
        let memory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        let instructions: Vec<_> = iter_instructions(memory).collect();

        assert_eq!(
            instructions,
            vec![
                Instr::Mul(2, 4),
                Instr::Mul(5, 5),
                Instr::Mul(11, 8),
                Instr::Mul(8, 5)
            ]
        )
    }

    #[test]
    fn should_extract_correct_do_dont_instructions() {
        let memory = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        let instructions: Vec<_> = iter_instructions(memory).collect();

        assert_eq!(
            instructions,
            vec![
                Instr::Mul(2, 4),
                Instr::Dont,
                Instr::Mul(5, 5),
                Instr::Mul(11, 8),
                Instr::Do,
                Instr::Mul(8, 5)
            ]
        )
    }

    #[test]
    fn should_eval_mul_instructions_correctly() {
        let instructions = vec![
            Instr::Mul(2, 4),
            Instr::Mul(5, 5),
            Instr::Mul(11, 8),
            Instr::Mul(8, 5),
        ];

        let result = eval_instructions(instructions.into_iter());

        assert_eq!(result, 161);
    }

    #[test]
    fn should_eval_do_cont_instructions_correctly() {
        let instructions = vec![
            Instr::Mul(2, 4),
            Instr::Dont,
            Instr::Mul(5, 5),
            Instr::Mul(11, 8),
            Instr::Do,
            Instr::Mul(8, 5),
        ];

        let result = eval_instructions(instructions.into_iter());

        assert_eq!(result, 48);
    }
}
