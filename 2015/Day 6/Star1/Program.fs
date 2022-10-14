open System.IO
open AdventOfCode.Y2015.Day6
open AdventOfCode.Y2015.Day6.Star1
open AdventOfCode.Y2015.Day6.Star1.Light
open Microsoft.FSharp.Core

type ProgramError =
    | NoPath
    | IO of string
    | Parse

let tryGetArg index args =
    args
    |> Array.tryItem index
    |> function
        | Some arg -> Ok arg
        | None -> Error NoPath

let tryReadFileAt path =
    try
        File.ReadLines path |> Seq.toList |> Ok
    with
    | _ -> Error(IO path)

let tryParse input =
    input
    |> List.map Parse.instruction
    |> Option.sequenceList
    |> function
        | Some instructions -> Ok instructions
        | None -> Error Parse

module Program =
    [<EntryPoint>]
    let main args =
        args
        |> tryGetArg 0
        |> Result.bind tryReadFileAt
        |> Result.bind tryParse
        |> Result.map (List.fold executeIn baseGrid)
        |> Result.map countLit
        |> function
            | Ok litCount ->
                printf $"There are %d{litCount} lit lights"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
