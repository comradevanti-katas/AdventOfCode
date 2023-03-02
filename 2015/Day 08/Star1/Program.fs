open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day8.Star1

let private eval lines =
    lines
    |> Seq.map (fun line ->
        let codeLength = line |> String.codeLength
        let dataLength = line |> String.dataLength
        codeLength - dataLength)
    |> Seq.sum

let private program =
    makeProgram allLines (parseEachWith Some) eval (fun count ->
        $"The count is %d{count}")

[<EntryPoint>]
let main args = program args
