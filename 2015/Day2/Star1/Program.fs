open System.IO
open AdventOfCode.Y2015.Day2
open AdventOfCode.Y2015.Day2.Star1

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
        File.ReadAllLines path |> Array.toList |> Ok
    with
    | _ -> Error(IO path)

let tryParse lines =
    lines
    |> List.map Parse.box
    |> Option.sequenceList
    |> function
        | Some boxes -> Ok boxes
        | None -> Error Parse

module Program =
    [<EntryPoint>]
    let main args =

        args
        |> tryGetArg 0
        |> Result.bind tryReadFileAt
        |> Result.bind tryParse
        |> Result.map Present.totalWrappingArea
        |> function
            | Ok area ->
                printf $"The total wrapping-area is %d{area}"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
