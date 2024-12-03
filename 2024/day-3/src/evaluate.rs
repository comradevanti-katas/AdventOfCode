pub fn evaluate_mul(mul: &(u32, u32)) -> u32 {
    mul.0 * mul.1
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn should_multiply_components() {
        let input = (3, 4);
        let actual = evaluate_mul(input);
        assert_eq!(actual, 12)
    }
}
