open System.IO
open AdventOfCode.Y2015.Day5.Star1.NaughtyNice

type ProgramError =
    | NoPath
    | IO of string

let tryGetArg index args =
    args
    |> Array.tryItem index
    |> function
        | Some arg -> Ok arg
        | None -> Error NoPath

let tryReadFileAt path =
    try
        File.ReadLines path |> seq |> Ok
    with
    | _ -> Error(IO path)

module Program =
    [<EntryPoint>]
    let main args =

        args
        |> tryGetArg 0
        |> Result.bind tryReadFileAt
        |> Result.map (Seq.filter isNice >> Seq.length)
        |> function
            | Ok count ->
                printf $"There are %d{count} nice strings"
                0
            | Error err ->
                printf $"Error: %A{err}"
                1
