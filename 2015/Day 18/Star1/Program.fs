module AdventOfCode.Y2015.Day18.Star1.Program

open AdventOfCode.AdventProgram
open LightAnimation

let private read = allText

let private parse = parseWith Parse.tryGrid

let private eval grid =
    grid |> animateTimes 100 |> onLightCount

let private makeMsg lights = $"There are %d{lights} on lights"

let private program = makeProgram read parse eval makeMsg

[<EntryPoint>]
let main args = program args
