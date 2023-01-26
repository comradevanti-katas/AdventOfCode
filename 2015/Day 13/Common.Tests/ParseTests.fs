module AdventOfCode.Y2015.Day13.ParseTests

open Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day13

[<Fact>]
let ``Relation is parsed correctly`` () =
    let s = "Alice would gain 54 happiness units by sitting next to Bob."
    let parsed = s |> Parse.tryRelation

    let expected =
        Some
            { Person = "Alice"
              Neighbor = "Bob"
              Effect = 54 }

    parsed =! expected
