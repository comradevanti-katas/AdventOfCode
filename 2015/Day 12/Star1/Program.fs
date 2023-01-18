open System.Text.RegularExpressions
open AdventOfCode.AdventProgram

let private numberRegex = Regex @"-?\d+"

let private eval json =
    let matches = numberRegex.Matches json
    let numbers = matches |> Seq.map (fun m -> m.Value) |> Seq.map int
    numbers |> Seq.sum

let private makeMsg sum = $"The sum is %i{sum}"

let private program = makeProgram (allText) (parseWith Some) eval makeMsg

[<EntryPoint>]
let main args = program args
