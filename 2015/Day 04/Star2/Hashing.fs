module AdventOfCode.Y2015.Day4.Star2.Hashing

open AdventOfCode.Y2015.Day4.Hashing

let isValidHash hash =
    if hash |> String.length >= 6 then
        hash |> Seq.take 6 |> Seq.forall ((=) '0')
    else
        false

let findNumberFor key =
    let rec findNumberStartingAt num =
        let fullKey = $"%s{key}%i{num}"

        if fullKey |> hash |> isValidHash then
            num
        else
            findNumberStartingAt (num + 1)

    findNumberStartingAt 1
