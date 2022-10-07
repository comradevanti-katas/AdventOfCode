module AdventOfCode.Y2015.Day4.Star1.Hashing

open System
open System.Security.Cryptography
open System.Text

let isValidHash hash =
    if hash |> String.length >= 5 then
        hash |> Seq.take 5 |> Seq.forall ((=) '0')
    else
        false

let hash (key: string) =
    let bytes = Encoding.ASCII.GetBytes key
    let hashed = MD5.HashData bytes
    Convert.ToHexString hashed

let findNumberFor key =
    let rec findNumberStartingAt num =
        let fullKey = $"%s{key}%i{num}"

        if fullKey |> hash |> isValidHash then
            num
        else
            findNumberStartingAt (num + 1)

    findNumberStartingAt 1
