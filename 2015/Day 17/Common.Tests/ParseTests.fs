module AdventOfCode.Y2015.Day17.ParseTests

open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``Can parse valid container`` () =
    let s = "123"
    let parsed = Parse.tryContainer 1u s
    parsed =! Some { Id = 1u; Capacity = 123u }