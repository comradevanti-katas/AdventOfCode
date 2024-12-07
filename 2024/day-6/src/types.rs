#[derive(PartialEq, Debug, Clone, Copy)]
pub enum Dir {
    Up,
    Right,
    Down,
    Left,
}

pub type Coord = i16;

pub type Pos = (Coord, Coord);

#[derive(PartialEq, Debug, Clone)]
pub struct Guard {
    pub pos: Pos,
    pub dir: Dir,
}

#[derive(PartialEq, Debug, Clone)]
pub struct Map {
    pub width: usize,
    pub height: usize,
    pub walls: Vec<Pos>,
}

#[derive(PartialEq, Debug, Clone)]
pub struct Input {
    pub map: Map,
    pub guard: Guard,
}
