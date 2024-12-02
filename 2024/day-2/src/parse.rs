pub fn report(line: &str) -> Vec<u8> {
    line.split_whitespace()
        .map(|n| n.parse::<u8>().expect("Must be number"))
        .collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_be_empty_for_empty_string() {
        let input = String::new();
        let report = report(&input);
        assert!(report.is_empty())
    }

    #[test]
    fn should_be_number_vector_for_valid_string() {
        let input = String::from("12 34");
        let report = report(&input);
        assert_eq!(vec![12, 34], report)
    }
}
