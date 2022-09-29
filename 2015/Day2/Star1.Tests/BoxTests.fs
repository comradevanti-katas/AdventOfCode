module AdventOfCode.Y2015.Day2.Star1.BoxTests

open AdventOfCode.Y2015.Day2
open Swensen.Unquote.Assertions

open Xunit

[<Theory>]
[<InlineData(1, 1, 1, 1)>]
[<InlineData(1, 2, 1, 1)>]
[<InlineData(1, 2, 3, 2)>]
[<InlineData(2, 5, 3, 6)>]
let ``The smallest side of the box has the smallest area`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let area = box |> Box.smallestSideArea
    area =! expected
