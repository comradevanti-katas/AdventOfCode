open System.IO
open AdventOfCode.Y2015.Day1
open AdventOfCode.Y2015.Day1.Star1

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
        File.ReadAllText path |> Ok
    with
    | _ -> Error(IO path)

let tryParse input =
    input
    |> Parse.sequence
    |> function
        | Some directions -> Ok directions
        | None -> Error Parse

module Program =
    [<EntryPoint>]
    let main args =

        args
        |> tryGetArg 0
        |> Result.bind tryReadFileAt
        |> Result.bind tryParse
        |> Result.map Floor.followDirections
        |> function
            | Ok floor ->
                printf $"Santa is on floor %d{floor}"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
