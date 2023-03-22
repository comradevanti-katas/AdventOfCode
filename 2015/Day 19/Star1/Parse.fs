[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day19.Star1.Parse

open AdventOfCode
open FSharp.Text.RegexProvider

type private ReplacementRegex =
    Regex< @"(?<from>[A-Za-z]+) => (?<to>[A-Za-z]+)" >

let private replacementRegex = ReplacementRegex()

let tryReplacement s =
    replacementRegex.TryTypedMatch s
    |> Option.map (fun m -> m.from.Value => m.``to``.Value)

let tryInput lines =
    let lineCount = lines |> List.length
    let replacementLines = lines |> List.take (lineCount - 2)
    let molecule = lines |> List.last

    replacementLines
    |> Option.traverseList tryReplacement
    |> Option.map (fun replacements -> (replacements, molecule))
