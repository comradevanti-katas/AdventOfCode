#[derive(PartialEq, Debug)]
pub struct Update(pub Vec<u8>);

impl Update {
    pub fn mid_value(&self) -> &u8 {
        let count = &self.0.len();
        assert!(count % 2 == 1);
        let i = count / 2;
        &self.0[i]
    }
}

#[derive(PartialEq, Debug)]
pub struct Rule(pub u8, pub u8);
