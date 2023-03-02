[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Star1.Present

open AdventOfCode.Y2015.Day2

let wrappingArea box = (box |> Box.surface) + (box |> Box.smallestSideArea)

let totalWrappingArea boxes = boxes |> List.sumBy wrappingArea
