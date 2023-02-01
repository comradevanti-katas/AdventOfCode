[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day14.Parse

open AdventOfCode.Y2015.Day14.Reindeer
open FSharp.Text.RegexProvider
open FSharp.Text.RegexExtensions

type private ReindeerRegex =
    Regex< @"^(?<name>[^ ]+)[^\d]+(?<speed>\d+)[^\d]+(?<flytime>\d+)[^\d]+(?<resttime>\d+)[^\d]+$" >

let private reindeerRegex = ReindeerRegex()

let toReindeer s =
    reindeerRegex.TryTypedMatch s
    |> Option.map (fun ``match`` ->
        let name = ``match``.name.Value
        let speed = ``match``.speed.AsInt
        let flyTime = ``match``.flytime.AsInt
        let restTime = ``match``.resttime.AsInt
        reindeer name speed flyTime restTime)
