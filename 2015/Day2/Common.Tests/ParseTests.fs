module AdventOfCode.Y2015.Day2.ParseTests

open FsCheck.Xunit
open Swensen.Unquote.Assertions
open Xunit

[<Property>]
let ``Boxes are serialized in the format [length]x[width]x[height]`` l w h =
    let input = $"%d{l}x%d{w}x%d{h}"
    let box = Parse.box input
    box =! Some { Length = l; Width = w; Height = h }

[<Theory>]
[<InlineData("10x2")>]
[<InlineData("3x5x")>]
[<InlineData("axbxc")>]
[<InlineData("")>]
[<InlineData("20a40b4")>]
[<InlineData("1 2 3")>]
let ``Inputs not matching [length]x[width]x[height] cannot be parsed`` input =
    (Parse.box input) =! None