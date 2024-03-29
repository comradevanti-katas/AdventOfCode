﻿module AdventOfCode.Y2015.Day2.BoxTests

open Xunit
open Swensen.Unquote.Assertions

[<Theory>]
[<InlineData(1, 1, 1, 1)>]
[<InlineData(2, 1, 1, 2)>]
[<InlineData(1, 2, 1, 1)>]
[<InlineData(3, 2, 4, 12)>]
let ``Box x-face area is length * height`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let area = box |> Box.xFaceArea
    area =! expected

[<Theory>]
[<InlineData(1, 1, 1, 1)>]
[<InlineData(1, 2, 1, 2)>]
[<InlineData(1, 1, 2, 1)>]
[<InlineData(3, 2, 4, 6)>]
let ``Box y-face area is length * width`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let area = box |> Box.yFaceArea
    area =! expected

[<Theory>]
[<InlineData(1, 1, 1, 1)>]
[<InlineData(1, 2, 1, 2)>]
[<InlineData(2, 1, 1, 1)>]
[<InlineData(3, 2, 4, 8)>]
let ``Box z-face area is width * height`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let area = box |> Box.zFaceArea
    area =! expected

[<Theory>]
[<InlineData(1, 1, 1, 6)>]
[<InlineData(1, 1, 2, 10)>]
[<InlineData(1, 2, 1, 10)>]
[<InlineData(2, 1, 1, 10)>]
[<InlineData(1, 2, 3, 22)>]
let ``Box surface is all area summed times 2`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let surface = box |> Box.surface
    surface =! expected

[<Theory>]
[<InlineData(1, 1, 1, 1)>]
[<InlineData(1, 1, 2, 2)>]
[<InlineData(2, 3, 4, 24)>]
let ``Box volume is all sides multiplied`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let volume = box |> Box.volume
    volume =! expected
    
[<Theory>]
[<InlineData(1, 1, 1, 4)>]
[<InlineData(1, 1, 2, 6)>]
[<InlineData(2, 1, 1, 4)>]
[<InlineData(2, 3, 4, 14)>]
let ``Box xy-perimeter is height + width times 2`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let perimeter = box |> Box.xyPerimeter
    perimeter =! expected

[<Theory>]
[<InlineData(1, 1, 1, 4)>]
[<InlineData(1, 1, 2, 6)>]
[<InlineData(1, 2, 1, 4)>]
[<InlineData(2, 3, 4, 12)>]
let ``Box zy-perimeter is height + length times 2`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let perimeter = box |> Box.zyPerimeter
    perimeter =! expected
    
[<Theory>]
[<InlineData(1, 1, 1, 4)>]
[<InlineData(1, 2, 1, 6)>]
[<InlineData(1, 1, 2, 4)>]
[<InlineData(2, 3, 4, 10)>]
let ``Box xz-perimeter is length + width times 2`` l w h expected =
    let box = { Length = l; Width = w; Height = h }
    let perimeter = box |> Box.xzPerimeter
    perimeter =! expected