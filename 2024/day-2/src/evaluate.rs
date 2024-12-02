use std::cmp;

fn is_directional(items: &[u8]) -> bool {
    if items.len() < 3 {
        return true;
    }

    let orderings = items
        .windows(2)
        .map(|pair| pair[0].cmp(&pair[1]))
        .collect::<Vec<_>>();

    orderings.iter().all(|&ord| ord == cmp::Ordering::Greater)
        || orderings.iter().all(|&ord| ord == cmp::Ordering::Less)
}

fn has_small_jumps(items: &[u8]) -> bool {
    let mut diffs = items.windows(2).map(|pair| pair[1] as i8 - pair[0] as i8);
    diffs.all(|diff| {
        let dist = diff.abs();
        dist >= 1 && dist <= 3
    })
}

pub fn is_strict_safe(report: &[u8]) -> bool {
    let is_directional = is_directional(report);
    let has_small_jumps = has_small_jumps(report);
    return is_directional && has_small_jumps;
}

pub fn is_loose_safe(report: &[u8]) -> bool {
    if is_strict_safe(report) {
        return true;
    }

    for skip_index in 0..report.len() {
        let loose_report = report
            .iter()
            .enumerate()
            .filter(|&(i, _)| i != skip_index)
            .map(|(_, &val)| val)
            .collect::<Vec<_>>();
        if is_strict_safe(&loose_report) {
            return true;
        }
    }

    false
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_be_directional_for_empty() {
        let input = Vec::new();
        let actual = is_directional(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_be_directional_for_single_element() {
        let input = vec![10];
        let actual = is_directional(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_be_directional_for_two_elements() {
        let input = vec![10, 11];
        let actual = is_directional(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_be_directional_for_n_directional_elements() {
        let input = vec![10, 11, 50];
        let actual = is_directional(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_not_be_directional_for_n_non_directional_elements() {
        let input = vec![10, 11, 50, 5];
        let actual = is_directional(&input);
        assert_eq!(false, actual)
    }

    #[test]
    fn should_have_small_jumps_for_empty() {
        let input = vec![];
        let actual = has_small_jumps(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_have_small_jumps_for_single() {
        let input = vec![10];
        let actual = has_small_jumps(&input);
        assert_eq!(true, actual)
    }

    #[test]
    fn should_not_have_small_jumps_if_a_number_is_repeated() {
        let input = vec![10, 10];
        let actual = has_small_jumps(&input);
        assert_eq!(false, actual)
    }

    #[test]
    fn should_not_have_small_jumps_if_there_is_a_gap_of_more_than_minus_3() {
        let input = vec![10, 6];
        let actual = has_small_jumps(&input);
        assert_eq!(false, actual)
    }

    #[test]
    fn should_not_have_small_jumps_if_there_is_a_gap_of_more_than_3() {
        let input = vec![10, 14];
        let actual = has_small_jumps(&input);
        assert_eq!(false, actual)
    }

    #[test]
    fn should_have_small_jumps_if_there_are_only_small_gaps() {
        let input = vec![10, 11, 13, 10, 8];
        let actual = has_small_jumps(&input);
        assert_eq!(true, actual)
    }
}
