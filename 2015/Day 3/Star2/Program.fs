open System.IO
open AdventOfCode.Y2015.Day3
open AdventOfCode.Y2015.Day3.Star1
open AdventOfCode.Y2015.Day3.Star2

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
    |> Parse.directions
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
        |> Result.map Sleigh.followWithRobo
        |> Result.map Map.count
        |> function
            | Ok count ->
                printf $"Santa and robo visited %d{count} houses"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
