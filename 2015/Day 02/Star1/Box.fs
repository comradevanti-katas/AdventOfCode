[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Star1.Box

open AdventOfCode.Y2015.Day2

let smallestSideArea box =
    List.min [ box |> Box.xFaceArea
               box |> Box.yFaceArea
               box |> Box.zFaceArea ]