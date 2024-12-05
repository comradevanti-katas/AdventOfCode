use crate::types::*;

impl Rule {
    fn applies_to(&self, update: &Update) -> bool {
        update.0.contains(&self.0) && update.0.contains(&self.1)
    }

    pub fn verify(&self, update: &Update) -> bool {
        if !self.applies_to(update) {
            return true;
        }

        let first_index = update
            .0
            .iter()
            .position(|it| *it == self.0)
            .expect("should contain rule values");
        let second_index = update
            .0
            .iter()
            .position(|it| *it == self.1)
            .expect("should contain rule values");
        first_index < second_index
    }
}

#[cfg(test)]
mod test {
    use super::*;

    #[test]
    fn should_apply_rule_to_update_which_contains_both_pages() {
        let update = Update(vec![75, 47, 61, 53, 29]);
        let rule = Rule(75, 53);

        let applies = rule.applies_to(&update);
        assert!(applies)
    }

    #[test]
    fn should_not_apply_rule_to_update_which_does_not_contain_either_page() {
        // Update does not include 53
        let update = Update(vec![75, 29, 13]);
        let rule = Rule(75, 53);

        let applies = rule.applies_to(&update);
        assert!(!applies)
    }

    #[test]
    fn should_verify_update_if_rule_does_not_apply() {
        // Update does not include 53
        let update = Update(vec![75, 29, 13]);
        let rule = Rule(75, 53);

        let ok = rule.verify(&update);
        assert!(ok)
    }

    #[test]
    fn should_verify_update_if_rule_is_followed() {
        let update = Update(vec![75, 47, 61, 53, 29]);
        let rule = Rule(75, 47);

        let ok = rule.verify(&update);
        assert!(ok)
    }

    #[test]
    fn should_not_verify_update_if_rule_is_not_followed() {
        let update = Update(vec![75, 97, 47, 61, 53]);
        let rule = Rule(97, 75);

        let ok = rule.verify(&update);
        assert!(!ok)
    }
}
