[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day6.List

let mapInRange min max f list =
    list
    |> List.mapi (fun i value -> if i >= min && i <= max then f value else value)
