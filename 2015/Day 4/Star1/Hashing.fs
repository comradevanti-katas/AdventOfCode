module AdventOfCode.Y2015.Day4.Star1.Hashing

let isValidHash hash =
    if hash |> String.length >= 5 then
        hash |> Seq.take 5 |> Seq.forall ((=) '0')
    else
        false
