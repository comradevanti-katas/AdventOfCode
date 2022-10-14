[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day6.Parse

open System
open System.Text.RegularExpressions

let private matchRegex =
    Regex
        @"(?<type>turn on|turn off|toggle) (?<x1>\d+),(?<y1>\d+) through (?<x2>\d+),(?<y2>\d+)"

let private instructionType s =
    if s = "turn on" then On
    elif s = "turn off" then Off
    else Toggle

let private parseInt = Int32.Parse

let instruction s =
    let m = matchRegex.Match s

    if m.Success then
        let t = instructionType m.Groups.["type"].Value
        let x1 = parseInt m.Groups["x1"].Value
        let y1 = parseInt m.Groups["y1"].Value
        let x2 = parseInt m.Groups["x2"].Value
        let y2 = parseInt m.Groups["y2"].Value
        Some { Type = t; From = (x1, y1); To = (x2, y2) }
    else
        None
