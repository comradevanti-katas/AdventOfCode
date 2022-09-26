[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day1.Parse

let single c =
    if c = '(' then Some Up
    elif c = ')' then Some Down
    else None
