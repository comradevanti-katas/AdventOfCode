[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day13.Parse

open System.Text.RegularExpressions

let private relationRegex =
    Regex
        @"(?<person>\w+) would (?<effect>\w+) (?<amount>\d+) happiness units by sitting next to (?<neighbor>\w+)."

let tryRelation s =
    let ``match`` = relationRegex.Match s

    if not ``match``.Success then
        None
    else
        let group (name: string) = ``match``.Groups.[name].Value

        let person = group "person"
        let effect = group "effect"
        let amount = group "amount" |> int
        let neighbor = group "neighbor"

        Some
            { Person = person
              Neighbor = neighbor
              Effect = amount * (if effect = "gain" then 1 else - 1) }
