module AdventOfCode.Y2015.Day7.Star1.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day7

let private read = allLines

let private parse = parseEachWith Parse.toPart

let private eval parts =
    let circuit = Circuit.makeFrom parts

    circuit
    |> Circuit.trySignalOn "a"
    |> Option.bind (fun signal ->
        let part = transport (Constant signal) "b"
        let circuit = circuit |> Circuit.putPart part
        circuit |> Circuit.trySignalOn "a")

let private makeMsg result =
    match result with
    | Some signal -> $"Signal on a is %u{signal}"
    | None -> "Signal could not be calculated"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
