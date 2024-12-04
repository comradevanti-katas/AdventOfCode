type CharMatrix = Vec<Vec<char>>;

const DIRS: [(i16, i16); 8] = [
    (1, 0),
    (1, -1),
    (0, -1),
    (-1, -1),
    (-1, 0),
    (-1, 1),
    (0, 1),
    (1, 1),
];

fn height_of(char_matrix: &CharMatrix) -> usize {
    char_matrix.len()
}

fn width_of(char_matrix: &CharMatrix) -> usize {
    if height_of(char_matrix) == 0 {
        return 0;
    }
    char_matrix[0].len()
}

fn char_at(char_matrix: &CharMatrix, x: i16, y: i16) -> Option<char> {
    let pos_is_out_of_matrix = x < 0
        || x as usize >= width_of(char_matrix)
        || y < 0
        || y as usize >= height_of(char_matrix);

    if pos_is_out_of_matrix {
        return None;
    }

    Some(char_matrix[y as usize][x as usize])
}

fn has_text_at(char_matrix: &CharMatrix, x: i16, y: i16, dx: &i16, dy: &i16, s: &str) -> bool {
    if s.len() == 0 {
        return true;
    }

    let mut chars = s.chars();
    let first_char = chars.next().unwrap();
    let remaining: String = chars.collect();

    if char_at(&char_matrix, x, y) != Some(first_char) {
        return false;
    }

    has_text_at(&char_matrix, x + dx, y + dy, dx, dy, &remaining)
}

pub fn text_in_matrix(char_matrix: &CharMatrix, search_text: &str) -> u16 {
    if height_of(char_matrix) == 0 || width_of(char_matrix) == 0 {
        return 0;
    }

    let hits_at = |(x, y): (usize, usize)| -> u16 {
        DIRS.iter()
            .map(|(dx, dy)| {
                if has_text_at(&char_matrix, x as i16, y as i16, dx, dy, &search_text) {
                    1
                } else {
                    0
                }
            })
            .sum()
    };

    (0..height_of(char_matrix))
        .flat_map(|y| (0..width_of(char_matrix)).map(move |x| (x, y)))
        .map(|pos| hits_at(pos))
        .sum()
}

#[cfg(test)]
mod tests {
    use super::*;
    use rstest::rstest;

    #[rstest]
    #[case(vec![vec![]], 0)]
    #[case(vec![vec!['X','M','A','S']], 1)]
    #[case(vec![vec!['S','A','M','X']], 1)]
    fn should_find_correct_number_of_XMAS(#[case] input: CharMatrix, #[case] expected: u16) {
        let actual = text_in_matrix(&input, "XMAS");
        assert_eq!(actual, expected)
    }
}
