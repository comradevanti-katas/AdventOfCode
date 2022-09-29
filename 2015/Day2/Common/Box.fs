[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Box

let yFaceArea box =
    box.Length * box.Width
    
let xFaceArea box =
    box.Length * box.Height
    
let zFaceArea box =
    box.Width * box.Height
    
let surface box =
    let xArea = box |> xFaceArea
    let yArea = box |> yFaceArea
    let zArea = box |> zFaceArea
    (xArea + yArea + zArea) * 2
    
let volume box = box.Length * box.Width * box.Height