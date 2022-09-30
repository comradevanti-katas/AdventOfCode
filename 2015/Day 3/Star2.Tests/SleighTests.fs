module AdventOfCode.Y2015.Day3.Star2.SleighTests

open Xunit
open AdventOfCode.Y2015.Day3
open AdventOfCode.Y2015.Day3.Star1
open Swensen.Unquote.Assertions

[<Fact>]
let ``Santa and Robo combine their visited houses`` () =
    let directions = [ Up; Right; Down; Left ]

    let expected =
        Map.ofSeq [ (Sleigh.origin, 4); ((0, 1), 1); ((1, 0), 1) ]

    let presentsByHouse = Sleigh.followWithRobo directions
    presentsByHouse =! expected
