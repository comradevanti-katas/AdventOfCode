module AdventOfCode.Y2015.Day1.Star2.FloorTests

open AdventOfCode.Y2015.Day1
open Xunit
open Swensen.Unquote.Assertions

[<Theory>]
[<InlineData(")", 1)>]
[<InlineData("()())", 5)>]
[<InlineData("((())))", 7)>]
let ``Correct instruction index found`` input expectedIndex =

    let basementIndex =
        input
        |> Parse.sequence
        |> Option.map Floor.findBasementIndexFor

    basementIndex =! expectedIndex
