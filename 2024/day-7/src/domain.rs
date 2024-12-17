use std::iter;

pub type Num = u64;

#[derive(PartialEq, Debug)]
pub struct Equation {
    pub result: Num,
    pub numbers: Vec<Num>,
}

#[derive(PartialEq, Debug)]
pub struct Input(pub Vec<Equation>);

#[derive(PartialEq, Debug, Clone, Copy)]
pub enum Operators {
    Add = 0,
    Multiply = 1,
}

const OPERATORS: [Operators; 2] = [Operators::Add, Operators::Multiply];

fn apply_operator(n1: Num, n2: Num, op: Operators) -> Num {
    match op {
        Operators::Add => n1 + n2,
        Operators::Multiply => n1 * n2,
    }
}

fn all_results<'a>(numbers: &'a [Num]) -> Box<dyn Iterator<Item = Num> + 'a> {
    if numbers.is_empty() {
        return Box::new(iter::empty());
    }

    let (last, rest) = numbers.split_last().expect("Must have 1");
    if numbers.len() == 1 {
        return Box::new(iter::once(last.clone()));
    }

    Box::new(all_results(rest).flat_map(move |result| {
        OPERATORS
            .into_iter()
            .map(move |op| apply_operator(last.clone(), result, op))
    }))
}

pub fn can_be_true(equation: &Equation) -> bool {
    let results: Vec<_> = all_results(&equation.numbers).collect();
    results.contains(&equation.result)
}

#[cfg(test)]
mod tests {
    use rstest::rstest;

    use super::*;

    #[test]
    fn should_add_for_add_operator() {
        let result = apply_operator(10, 19, Operators::Add);
        assert_eq!(result, 29)
    }

    #[test]
    fn should_multiply_for_mult_operator() {
        let result = apply_operator(10, 19, Operators::Multiply);
        assert_eq!(result, 190)
    }

    #[rstest]
    #[case(vec![10, 19], vec![29, 190])]
    #[case(vec![81, 40, 27], vec![148, 3267, 3267, 87480])]
    #[case(vec![11, 6, 16, 20], vec![53, 660, 292, 5440, 102, 1640, 1076, 21120])]
    fn should_find_all_possible_results(#[case] numbers: Vec<Num>, #[case] expected: Vec<Num>) {
        let actual: Vec<_> = all_results(&numbers).collect();
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("190: 10 19", true)]
    #[case("3267: 81 40 27", true)]
    #[case("161011: 16 10 13", false)]
    #[case("21037: 9 7 18 13", false)]
    fn should_determine_if_equation_can_be_true(
        #[case] equation: Equation,
        #[case] expected: bool,
    ) {
        let actual = can_be_true(&equation);
        assert_eq!(actual, expected)
    }
}
