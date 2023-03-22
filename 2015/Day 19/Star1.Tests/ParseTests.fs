module AdventOfCode.Y2015.Day19.Star1.ParseTests

open Swensen.Unquote.Assertions
open Xunit

[<Fact>]
let ``Can parse valid replacements`` () =
    let s = "H => HO"
    let expected = "H" => "HO"
    s |> Parse.tryReplacement =! Some expected
