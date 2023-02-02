module AdventOfCode.Y2015.Day16.Star1.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day16
open AdventOfCode.Y2015.Day16.Star1.SueDetection

let private read = allLines

let private parse = parseEachWith Parse.toSue

let private eval sues =
    let sue = findSue sues
    sue.Number

let private makeMsg num = $"The present was made by Sue %d{num}."

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
