[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Star2.Box

open AdventOfCode.Y2015.Day2

let smallestPerimeter box =
    List.min [ box |> Box.xyPerimeter
               box |> Box.xzPerimeter
               box |> Box.zyPerimeter ]
