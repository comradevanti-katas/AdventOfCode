[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day17.Parse

open System

let private tryUInt s =
    try
        UInt32.Parse s |> Some
    with _ ->
        None

let tryContainer id s =
    tryUInt s |> Option.map (fun capacity -> { Id = id; Capacity = capacity })
