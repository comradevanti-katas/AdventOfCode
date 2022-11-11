open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day8
open AdventOfCode.Y2015.Day8.Star2

let private eval lines =
    lines
    |> Seq.map (fun line ->
        let dataLength = line |> String.length
        let encoded = line |> String.encode
        let encodedLength = encoded |> String.length
        encodedLength - dataLength)
    |> Seq.sum

let private program =
    makeProgram allLines (parseEachWith Some) eval (fun count ->
        $"The count is %d{count}")

[<EntryPoint>]
let main args = program args
