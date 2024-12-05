use crate::types::*;

#[derive(PartialEq, Debug)]
pub struct Input(pub Vec<Rule>, pub Vec<Update>);

impl Rule {
    fn from_str(s: &str) -> Self {
        let parts: Vec<u8> = s
            .split("|")
            .map(|part| part.trim().parse().expect("Must be u8"))
            .collect();
        assert!(parts.len() == 2);

        Rule(parts[0], parts[1])
    }
}

impl Update {
    fn from_str(s: &str) -> Self {
        let pages: Vec<u8> = s
            .trim()
            .split(",")
            .map(|part| part.parse().expect("Must be u8"))
            .collect();
        Update(pages)
    }
}

impl Input {
    pub fn from_str(s: &str) -> Self {
        let lines: Vec<&str> = s.lines().map(|line| line.trim()).collect();
        let split_line_index = lines
            .iter()
            .position(|line| line.len() == 0)
            .expect("Must have separator line");
        let rule_lines = &lines[0..split_line_index];
        let update_lines = &lines[split_line_index + 1..];

        let rules = rule_lines.iter().map(|line| Rule::from_str(line)).collect();
        let updates = update_lines
            .iter()
            .map(|line| Update::from_str(line))
            .collect();

        Input(rules, updates)
    }
}

#[cfg(test)]
mod tests {
    use rstest::rstest;

    use super::*;

    #[rstest]
    #[case("1|2", Rule(1, 2))]
    #[case("50|90", Rule(50, 90))]
    #[case("  10|3\n", Rule(10, 3))]
    fn should_parse_valid_rule(#[case] input: &str, #[case] expected: Rule) {
        let actual = Rule::from_str(input);
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case("75,47,61,53,29", Update(vec![75,47,61,53,29]))]
    #[case("97,61,53,29,13", Update(vec![97,61,53,29,13]))]
    #[case("   75,29,13\n", Update(vec![75,29,13]))]
    fn should_parse_valid_update(#[case] input: &str, #[case] expected: Update) {
        let actual = Update::from_str(input);
        assert_eq!(actual, expected)
    }

    #[rstest]
    #[case(
        "47|53
    
    75,47,61,53,29", Input(vec![Rule(47,53)], vec![Update(vec![75,47,61,53,29])])
    )]
    fn should_parse_valid_input(#[case] input: &str, #[case] expected: Input) {
        let actual = Input::from_str(input);
        assert_eq!(actual, expected)
    }
}
