module AdventOfCode.Y2015.Day19.Star1.Program

open AdventOfCode.AdventProgram
open Calibration

let private read = allLines

let private parse = parseWith Parse.tryInput

let private eval (replacements, molecule) =
    calibrate replacements molecule |> Set.count

let private makeMsg count = $"There are %d{count} molecules"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
