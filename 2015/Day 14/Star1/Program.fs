module AdventOfCode.Y2015.Day14.Star1.Program

open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day14
open AdventOfCode.Y2015.Day14.Star1.ReindeerRacing

let private read = allLines

let private parse = parseEachWith Parse.toReindeer

let private eval reindeer = findTopDistance reindeer 2503

let private makeMsg time = $"The fastest time was %d{time}"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
