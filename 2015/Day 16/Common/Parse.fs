[<RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day16.Parse

open FSharp.Text.RegexExtensions
open FSharp.Text.RegexProvider

type private NumberRegex = Regex< @"Sue (?<num>\d+)" >

type private CompoundRegex = Regex< @"(?<compound>[a-z]+): (?<amount>\d+)" >

let private numberRegex = NumberRegex()

let private compoundRegex = CompoundRegex()

let toSue s =
    let compounds =
        compoundRegex.TypedMatches s
        |> Seq.map (fun m -> (m.compound.Value, m.amount.AsInt))

    numberRegex.TryTypedMatch s
    |> Option.map (fun m -> m.num.AsInt)
    |> Option.map (fun number -> makeSue number compounds)
