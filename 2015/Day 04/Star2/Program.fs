open System.IO
open AdventOfCode.Y2015.Day4.Star2.Hashing

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

module Program =
    [<EntryPoint>]
    let main args =

        args
        |> tryGetArg 0
        |> Result.bind tryReadFileAt
        |> Result.map findNumberFor
        |> function
            | Ok number ->
                printf $"The number for the correct hash is %d{number}"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
