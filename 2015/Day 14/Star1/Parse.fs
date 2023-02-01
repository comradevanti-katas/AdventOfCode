[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day14.Star1.Parse

open AdventOfCode.Y2015.Day14.Star1.Reindeer
open FSharp.Text.RegexProvider
open FSharp.Text.RegexExtensions

type private ReindeerRegex =
    Regex< @"^[^\d]+(?<speed>\d+)[^\d]+(?<flytime>\d+)[^\d]+(?<resttime>\d+)[^\d]+$" >

let private reindeerRegex = ReindeerRegex()

let toReindeer s =
    reindeerRegex.TryTypedMatch s
    |> Option.map (fun ``match`` ->
        let speed = ``match``.speed.AsInt
        let flyTime = ``match``.flytime.AsInt
        let restTime = ``match``.resttime.AsInt
        reindeer speed flyTime restTime)
