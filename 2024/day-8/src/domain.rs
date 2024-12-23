use std::collections::{HashMap, HashSet};

type Antenna = char;

#[derive(Clone, PartialEq, Debug, Eq, Hash, Copy)]
pub struct Pos {
    x: isize,
    y: isize,
}

impl Pos {
    pub fn new(x: isize, y: isize) -> Self {
        Self { x, y }
    }
}

#[derive(Clone, PartialEq, Debug)]
pub struct Map {
    width: usize,
    height: usize,
    antennas: HashMap<Pos, Antenna>,
}

pub struct Input {
    pub map: Map,
}

impl Map {
    pub fn antennas(&self) -> Box<dyn Iterator<Item = &Antenna> + '_> {
        Box::new(self.antennas.values().collect::<HashSet<_>>().into_iter())
    }

    pub fn empty(width: usize, height: usize) -> Self {
        Self {
            width,
            height,
            antennas: HashMap::new(),
        }
    }

    pub fn add_antenna(&self, pos: &Pos, antenna: Antenna) -> Self {
        let mut antenna_clone = self.antennas.clone();
        antenna_clone.insert(pos.clone(), antenna);
        Self {
            antennas: antenna_clone,
            ..*self
        }
    }

    pub fn contains(&self, pos: &Pos) -> bool {
        pos.x >= 0 && pos.x < self.width as isize && pos.y >= 0 && pos.y < self.height as isize
    }

    fn find_anti_nodes_between(&self, a: &Pos, b: &Pos) -> (Pos, Pos) {
        let dx = (b.x as isize) - (a.x as isize);
        let dy = (b.y as isize) - (a.y as isize);

        let node_a = Pos::new(a.x - dx, a.y - dy);
        let node_b = Pos::new(b.x + dx, b.y + dy);

        (node_a, node_b)
    }

    fn find_anti_nodes_between_all(&self, points: &[Pos]) -> HashSet<Pos> {
        let mut anti_nodes = HashSet::new();

        for i_a in 0..points.len() - 1 {
            for i_b in (i_a + 1)..points.len() {
                let point_a = &points[i_a];
                let point_b = &points[i_b];

                let (node_a, node_b) = self.find_anti_nodes_between(point_a, point_b);

                anti_nodes.insert(node_a);
                anti_nodes.insert(node_b);
            }
        }

        anti_nodes
    }

    fn points_for(&self, antenna: Antenna) -> HashSet<Pos> {
        self.antennas
            .iter()
            .filter(|(_, &a)| a == antenna)
            .map(|(&pos, _)| pos)
            .collect()
    }

    pub fn find_anti_nodes_for(&self, antenna: Antenna) -> HashSet<Pos> {
        let points: Vec<Pos> = self.points_for(antenna).iter().cloned().collect();
        self.find_anti_nodes_between_all(&points)
    }
}

#[cfg(test)]
mod tests {
    use super::*;
    use maplit::hashset;
    use rstest::rstest;

    #[test]
    fn should_find_anti_nodes_between_two_points() {
        let map = Map::empty(10, 10);

        let anti_nodes = map.find_anti_nodes_between(&Pos::new(4, 3), &Pos::new(5, 5));

        assert_eq!(anti_nodes, (Pos::new(3, 1), Pos::new(6, 7)))
    }

    #[test]
    fn should_find_anti_nodes_between_set_of_points() {
        let map = Map::empty(10, 10);

        let anti_nodes =
            map.find_anti_nodes_between_all(&vec![Pos::new(4, 3), Pos::new(5, 5), Pos::new(8, 4)]);

        assert_eq!(
            anti_nodes,
            hashset![
                Pos::new(3, 1),
                Pos::new(6, 7),
                Pos::new(0, 2),
                Pos::new(2, 6),
                Pos::new(11, 3),
                Pos::new(12, 5)
            ]
        )
    }

    #[test]
    fn should_find_anti_nodes_for_antenna() {
        let map = Map::empty(10, 10)
            .add_antenna(&Pos::new(4, 3), 'a')
            .add_antenna(&Pos::new(5, 5), 'a')
            .add_antenna(&Pos::new(8, 4), 'a')
            .add_antenna(&Pos::new(6, 7), 'A');

        let anti_nodes = map.find_anti_nodes_for('a');

        assert_eq!(
            anti_nodes,
            hashset![
                Pos::new(3, 1),
                Pos::new(6, 7),
                Pos::new(0, 2),
                Pos::new(2, 6),
                Pos::new(11, 3),
                Pos::new(12, 5)
            ]
        )
    }

    #[test]
    fn should_filter_out_out_of_map_anti_nodes() {
        let map = Map::empty(10, 10)
            .add_antenna(&Pos::new(4, 3), 'a')
            .add_antenna(&Pos::new(5, 5), 'a')
            .add_antenna(&Pos::new(8, 4), 'a')
            .add_antenna(&Pos::new(6, 7), 'A');

        let anti_nodes: HashSet<_> = map
            .find_anti_nodes_for('a')
            .iter()
            .cloned()
            .filter(|it| map.contains(it))
            .collect();

        assert_eq!(
            anti_nodes,
            hashset![
                Pos::new(3, 1),
                Pos::new(6, 7),
                Pos::new(0, 2),
                Pos::new(2, 6),
            ]
        )
    }
}
