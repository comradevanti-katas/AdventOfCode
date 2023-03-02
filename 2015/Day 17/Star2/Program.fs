module AdventOfCode.Y2015.Day17.Star2.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day17

let private read = allLines

let private parse =
    let mutable id = 0u

    parseEachWith (fun s ->
        id <- id + 1u
        Parse.tryContainer id s)

let private eval containers =
    let combinations = containers |> combinationsFor 150u |> Seq.toList
    let minContainerCount = combinations |> List.map Set.count |> List.min

    combinations
    |> List.filter (Set.count >> (=) minContainerCount)
    |> List.length

let private makeMsg combinations =
    $"There are %d{combinations} combinations"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
