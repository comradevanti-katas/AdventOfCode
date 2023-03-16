[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day18.Parse

open System
open AdventOfCode
open Microsoft.FSharp.Core

let tryLight c =
    if c = '.' then Some offLight
    elif c = '#' then Some onLight
    else None

let tryGrid (s: string) =
    let lines = s.Split Environment.NewLine |> List.ofArray

    let tryParseLine line =
        line |> List.ofSeq |> Option.traverseList tryLight

    lines |> Option.traverseList tryParseLine |> Option.map gridOf
