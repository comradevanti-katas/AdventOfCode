open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day12.Star2.JSONValidation

let private eval json = sumIn json

let private makeMsg sum = $"The sum is %i{sum}"

let private program = makeProgram (allText) (parseWith Some) eval makeMsg

[<EntryPoint>]
let main args = program args
