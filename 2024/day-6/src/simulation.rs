use crate::types::*;

fn turn(dir: &Dir) -> Dir {
    match dir {
        Dir::Up => Dir::Right,
        Dir::Right => Dir::Down,
        Dir::Down => Dir::Left,
        Dir::Left => Dir::Up,
    }
}

fn project_pos((x, y): &Pos, dir: &Dir) -> Pos {
    match dir {
        Dir::Up => (*x, y - 1),
        Dir::Right => (x + 1, *y),
        Dir::Down => (*x, y + 1),
        Dir::Left => (x - 1, *y),
    }
}

pub fn simulate_guard(map: &Map, guard: &Guard) -> Guard {
    let next_dir = guard.dir;
    let next_pos = project_pos(&guard.pos, &next_dir);
    if !map.is_obstructed(&next_pos) {
        return Guard {
            pos: next_pos,
            dir: next_dir,
        };
    }

    simulate_guard(
        map,
        &Guard {
            pos: guard.pos,
            dir: turn(&next_dir),
        },
    )
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;

    #[rstest]
    #[case(Dir::Up, Dir::Right)]
    #[case(Dir::Right, Dir::Down)]
    #[case(Dir::Down, Dir::Left)]
    #[case(Dir::Left, Dir::Up)]
    fn should_turn_dir_correctly(#[case] input: Dir, #[case] expected: Dir) {
        let actual = turn(&input);
        assert_eq!(actual, expected);
    }

    fn make_test_map() -> Map {
        "....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#..."
            .parse()
            .expect("Should parse")
    }

    #[test]
    fn should_move_guard_up_if_there_is_no_obstruction() {
        let map = make_test_map();
        let guard = Guard {
            pos: (4, 6),
            dir: Dir::Up,
        };
        let actual = simulate_guard(&map, &guard);

        assert_eq!(
            actual,
            Guard {
                pos: (4, 5),
                dir: Dir::Up
            }
        )
    }

    #[test]
    fn should_move_guard_right_if_there_is_no_obstruction() {
        let map = make_test_map();
        let guard = Guard {
            pos: (5, 1),
            dir: Dir::Right,
        };
        let actual = simulate_guard(&map, &guard);

        assert_eq!(
            actual,
            Guard {
                pos: (6, 1),
                dir: Dir::Right
            }
        )
    }

    #[test]
    fn should_turn_and_move_guard_right_if_there_is_obstacle_ahead() {
        let map = make_test_map();
        let guard = Guard {
            pos: (4, 1),
            dir: Dir::Up,
        };
        let actual = simulate_guard(&map, &guard);

        assert_eq!(
            actual,
            Guard {
                pos: (5, 1),
                dir: Dir::Right
            }
        )
    }
}
