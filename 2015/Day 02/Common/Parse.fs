[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Parse

open System

let private tryParseInt s =
    try
        Int32.Parse s |> Some
    with
    | _ -> None

let box (s: string) =
    match s.Split 'x' with
    | [| ls; ws; hs |] ->
        match (tryParseInt ls, tryParseInt ws, tryParseInt hs) with
        | Some l, Some w, Some h -> Some { Length = l; Width = w; Height = h }
        | _ -> None
    | _ -> None