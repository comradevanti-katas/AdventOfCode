use std::{num::ParseIntError, str::FromStr};

use crate::domain::*;

type EquationParseError = ParseIntError;

impl FromStr for Equation {
    type Err = EquationParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let parts: Vec<_> = s.split(':').collect();
        let result = parts[0].parse()?;
        let numbers = parts[1]
            .split_whitespace()
            .map(|n| n.parse())
            .collect::<Result<_, _>>()?;

        Ok(Equation {
            result: result,
            numbers: numbers,
        })
    }
}

impl FromStr for Input {
    type Err = EquationParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        let equations = s
            .lines()
            .map(|line| line.parse())
            .collect::<Result<_, _>>()?;
        Ok(Input(equations))
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;

    #[rstest]
    #[case("190: 10 19", Equation { result: 190, numbers:vec![10,19]})]
    #[case("3267: 81 40 27", Equation { result: 3267, numbers:vec![81,40,27]})]
    fn should_parse_equation(#[case] input: &str, #[case] expected: Equation) {
        let actual: Equation = input.parse().expect("Should parse");
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("83: 17 5\n156: 15 6\n7290: 6 8 6 15", Input (vec![
        Equation { result: 83, numbers: vec![17, 5]},
        Equation { result: 156, numbers: vec![15, 6]},
        Equation { result: 7290, numbers: vec![6, 8, 6, 15]},
    ]))]
    fn should_parse_input(#[case] input: &str, #[case] expected: Input) {
        let actual: Input = input.parse().expect("Should parse");
        assert_eq!(actual, expected)
    }
}
