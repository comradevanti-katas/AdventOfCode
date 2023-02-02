module AdventOfCode.Y2015.Day16.ParseTests

open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``Can parse valid sue`` () =
    let s = "Sue 484: akitas: 2, goldfish: 4, perfumes: 10"

    let expected =
        makeSue 484 [ ("akitas", 2); ("goldfish", 4); ("perfumes", 10) ]

    Parse.toSue s =! Some expected
