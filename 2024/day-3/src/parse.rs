use regex::Regex;

pub fn mul(s: &str) -> Vec<(u32, u32)> {
    let mul_regex: Regex = Regex::new(r"mul\((\d{1,3}),(\d{1,3})\)").unwrap();
    mul_regex
        .captures_iter(s)
        .map(|c| c.extract())
        .map(|(_, [a, b])| {
            (
                a.parse::<u32>().expect("Must be number"),
                b.parse::<u32>().expect("Must be number"),
            )
        })
        .collect()
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_parse_single_valid_entry() {
        let input = "mul(1,2)";
        let parsed = mul(&input);
        assert_eq!(parsed, vec![(1, 2)])
    }

    #[test]
    fn should_parse_single_valid_entry_with_noise() {
        let input = "xXx_mul(3,4)_xXx";
        let parsed = mul(&input);
        assert_eq!(parsed, vec![(3, 4)])
    }

    #[test]
    fn should_parse_multiple_valid_entries_with_noise() {
        let input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        let parsed = mul(&input);
        assert_eq!(parsed, vec![(2, 4), (5, 5), (11, 8), (8, 5)])
    }
}
