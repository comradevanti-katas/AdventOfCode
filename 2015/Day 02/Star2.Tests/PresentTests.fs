module AdventOfCode.Y2015.Day2.Star2.PresentTests

open AdventOfCode.Y2015.Day2
open Swensen.Unquote.Assertions
open Xunit

[<Theory>]
[<InlineData(2, 3, 4, 34)>]
[<InlineData(1, 1, 10, 14)>]
let ``Ribbon-length is shortest perimeter + box volume`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let length = Present.ribbonLength box
    length =! expected
