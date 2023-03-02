module AdventOfCode.Y2015.Day17.Star1.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day17

let private read = allLines

let private parse =
    let mutable id = 0u
    parseEachWith (fun s ->
        id <- id + 1u
        Parse.tryContainer id s)

let private eval containers =
    containers |> combinationsFor 150u |> Seq.length

let private makeMsg combinations =
    $"There are %d{combinations} combinations"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
