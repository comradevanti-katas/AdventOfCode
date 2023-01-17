module AdventOfCode.AdventProgram

open System.IO
open Microsoft.FSharp.Core

type ConsoleApp = string [] -> int

type Error =
    | NoPath
    | IO of string
    | Parse

let private tryGetArg index args =
    args
    |> Array.tryItem index
    |> function
        | Some arg -> Ok arg
        | None -> Error NoPath

let private tryReadTextAt path =
    try
        File.ReadAllText path |> Ok
    with
    | _ -> Error(IO path)

let private tryReadLinesAt path =
    try
        File.ReadLines path |> Seq.toList |> Ok
    with
    | _ -> Error(IO path)

let parseEachWith f =
    (fun input ->
        input
        |> List.map f
        |> Option.sequenceList
        |> function
            | Some instructions -> Ok instructions
            | None -> Error Parse)

let parseWith f =
    (fun input ->
        f input
        |> function
            | Some instructions -> Ok instructions
            | None -> Error Parse)

let allText = tryReadTextAt

let allLines = tryReadLinesAt

let makeProgram read parse eval makeMsg : ConsoleApp =
    (fun (args: string []) ->
        let path = args |> tryGetArg 0
        let content = path |> Result.bind read
        let parsed = content |> Result.bind parse
        let result = parsed |> Result.map eval

        match result with
        | Ok value ->
            printf (makeMsg value)
            0
        | Error err ->
            printf $"Error: %A{err}"
            1)
