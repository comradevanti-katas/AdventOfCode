open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day10
open AdventOfCode.Y2015.Day10.Star1.LookSay

let private eval blocks =

    let rec lookSayTimes remaining blocks =
        if remaining = 0 then
            blocks
        else
            blocks |> lookSay |> lookSayTimes (remaining - 1)

    blocks |> lookSayTimes 40 |> stringify |> String.length

let private makeMsg length = $"The final length is %i{length}"

let private program =
    makeProgram (allText) (parseWith Parse.tryBlockSequence) eval makeMsg

[<EntryPoint>]
let main args = program args
