module AdventOfCode.Y2015.Day9.Parse

open System
open System.Text.RegularExpressions
open AdventOfCode.Y2015.Day9

let private regex =
    Regex @"(?<a>[a-zA-Z]+) to (?<b>[a-zA-Z]+) = (?<dist>\d+)$"

let toDistanceBetweenLocations line =
    let ``match`` = regex.Match line

    if ``match``.Success then
        let a = ``match``.Groups["a"].Value
        let b = ``match``.Groups["b"].Value
        let dist = ``match``.Groups["dist"].Value |> Int32.Parse
        Some(between a b, dist)
    else
        None
