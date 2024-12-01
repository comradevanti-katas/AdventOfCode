use std::env;
use std::fs;
use std::io;

fn split_tuples<T, U>(it: Vec<(T, U)>) -> (Vec<T>, Vec<U>) {
    let mut first_elements = Vec::new();
    let mut second_elements = Vec::new();

    for (first, second) in it {
        first_elements.push(first);
        second_elements.push(second);
    }

    (first_elements, second_elements)
}

fn parse_lists(s: &String) -> (Vec<i32>, Vec<i32>) {
    return split_tuples(
        s.lines()
            .map(|line| -> Vec<i32> {
                line.split_whitespace()
                    .map(|n| -> i32 { n.parse().expect("Could not parse number") })
                    .collect()
            })
            .map(|ns| (ns[0], ns[1]))
            .collect(),
    );
}

fn count_occurrences(vec: &Vec<i32>, value: i32) -> usize {
    vec.iter().filter(|&&x| x == value).count()
}

fn calc_sum_similarity(left: &Vec<i32>, right: &Vec<i32>) -> i32 {
    let mut left = left.clone();
    left.sort();
    let mut right = right.clone();
    right.sort();
    let distances = left.iter().zip(right.iter()).map(|(a, b)| (b - a).abs());

    return distances.sum();
}

fn calc_count_similarity(left: &Vec<i32>, right: &Vec<i32>) -> i32 {
    left.iter()
        .map(|&value| value * count_occurrences(right, value) as i32)
        .sum()
}

fn main() -> io::Result<()> {
    let args: Vec<String> = env::args().collect();
    let file_path = &args[1];

    let input = fs::read_to_string(file_path)?;
    let (left, right) = parse_lists(&input);

    println!("Sum similarity: {}", calc_sum_similarity(&left, &right));
    println!("Count similarity: {}", calc_count_similarity(&left, &right));
    Ok(())
}
