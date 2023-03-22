module AdventOfCode.Y2015.Day19.Star1.Calibration

open System.Collections.Generic
open System.Text.RegularExpressions
open Microsoft.FSharp.Core

let private tryIndexOf (search: string) (startIndex: int) (s: string) =
    let index = s.IndexOf(search, startIndex)
    if index >= 0 then Some index else None

let private indicesOf search s =
    let rec indicesAfter start =
        s
        |> tryIndexOf search start
        |> Option.map (fun index ->
            seq {
                yield index
                yield! indicesAfter (start + 1)
            })
        |> Option.defaultValue Seq.empty

    indicesAfter 0

let calibrate replacements molecule =

    let calibrateWith replacement =
        let regex = Regex replacement.From

        molecule
        |> indicesOf replacement.From
        |> Seq.map (fun index ->
            regex.Replace(molecule, replacement.To, 1, index))

    replacements |> Seq.collect calibrateWith |> Set.ofSeq
