module AdventOfCode.Y2015.Day5.Star2.NaughtyNice

open System.Text.RegularExpressions


let private isolatedPairsRegex = Regex @".*(.{2}).*\1.*"
let private oneBetweenRegex = Regex @".*(.{1}).{1}\1.*"

let isNice s =
    s |> isolatedPairsRegex.IsMatch
    && s |> oneBetweenRegex.IsMatch
