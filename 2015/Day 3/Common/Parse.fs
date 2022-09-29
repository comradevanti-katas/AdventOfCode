[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day3.Parse

let direction c =
    if c = '^' then Some Up
    elif c = '>' then Some Right
    elif c = 'v' then Some Down
    elif c = '<' then Some Left
    else None

let directions s = s |> Seq.map direction |> Seq.toList |> Option.sequenceList
