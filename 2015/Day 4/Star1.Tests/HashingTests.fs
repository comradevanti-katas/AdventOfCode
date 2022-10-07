module AdventOfCode.Y2015.Day4.Star1.HashingTests

open Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day4.Star1.Hashing

[<Theory>]
[<InlineData("00000123")>]
[<InlineData("00000abc")>]
[<InlineData("000007846746876847687")>]
[<InlineData("00000023jk35fdf42jkjj")>]
let ``Hashes starting with 5 zeroes are valid`` hash =
    hash |> isValidHash =! true

[<Theory>]
[<InlineData("0000123")>]
[<InlineData("abc")>]
[<InlineData("")>]
let ``Hashes not starting with 5 zeroes are invalid`` hash =
    hash |> isValidHash =! false