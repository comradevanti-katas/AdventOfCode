[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Star2.Present

open AdventOfCode.Y2015.Day2
open AdventOfCode.Y2015.Day2.Star2

let ribbonLength box = (box |> Box.smallestPerimeter) + (box |> Box.volume)
