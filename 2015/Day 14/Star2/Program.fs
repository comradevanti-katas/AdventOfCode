module AdventOfCode.Y2015.Day14.Star2.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day14
open AdventOfCode.Y2015.Day14.Star2.ReindeerRacing

let private read = allLines

let private parse = parseEachWith Parse.toReindeer

let private eval reindeer = winnerPoints reindeer 2503

let private makeMsg points = $"The winners points are %d{points}"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
