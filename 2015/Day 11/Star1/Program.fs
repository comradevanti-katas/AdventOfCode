open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day11.PasswordGen

let private eval startPassword = startPassword |> findNextPassword

let private makeMsg password = $"The next password is %s{password}"

let private program = makeProgram (allText) (parseWith Some) eval makeMsg

[<EntryPoint>]
let main args = program args
