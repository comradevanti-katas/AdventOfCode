module AdventOfCode.Y2015.Day15.Star1.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day15
open AdventOfCode.Y2015.Day15.Star1.Cookie

let private read = allLines

let private parse = parseEachWith Parse.toIngredient

let private eval ingredients = findOptimalScoreFor ingredients

let private makeMsg score = $"The best score was %d{score}"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
