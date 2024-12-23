use std::str::FromStr;

use crate::domain::*;

type InputParseError = ();

impl FromStr for Input {
    type Err = InputParseError;

    fn from_str(s: &str) -> Result<Self, Self::Err> {
        todo!()
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;
}
