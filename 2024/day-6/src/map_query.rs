use crate::types::*;

impl Map {
    pub fn is_obstructed(&self, pos: &Pos) -> bool {
        self.walls.contains(pos)
    }

    pub fn contains_pos(&self, pos: &Pos) -> bool {
        pos.0 >= 0 && pos.1 >= 0 && pos.0 < self.width as Coord && pos.1 < self.height as Coord
    }
}
