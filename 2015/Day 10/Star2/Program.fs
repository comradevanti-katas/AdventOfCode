open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day10
open AdventOfCode.Y2015.Day10.LookSay

let private eval blocks =
    blocks |> lookSayTimes 50 |> stringify |> String.length

let private makeMsg length = $"The final length is %i{length}"

let private program =
    makeProgram (allText) (parseWith Parse.tryBlockSequence) eval makeMsg

[<EntryPoint>]
let main args = program args
