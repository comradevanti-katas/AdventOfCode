module AdventOfCode.Y2015.Day2.Star1.PresentTests

open Xunit
open AdventOfCode.Y2015.Day2
open AdventOfCode.Y2015.Day2.Star1
open Swensen.Unquote.Assertions

[<Theory>]
[<InlineData(1, 1, 1, 7)>]
[<InlineData(1, 2, 1, 11)>]
[<InlineData(3, 4, 5, 106)>]
let ``Wrapping-paper area is box area + area of smallest side`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let area = box |> Present.wrappingArea
    area =! expected
