module AdventOfCode.Y2015.Day4.Star2.HashingTests

open Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day4.Star2.Hashing

[<Theory>]
[<InlineData("000000123")>]
[<InlineData("000000abc")>]
[<InlineData("0000007846746876847687")>]
[<InlineData("000000023jk35fdf42jkjj")>]
let ``Hashes starting with 6 zeroes are valid`` hash =
    hash |> isValidHash =! true

[<Theory>]
[<InlineData("00000123")>]
[<InlineData("abc")>]
[<InlineData("")>]
let ``Hashes not starting with 6 zeroes are invalid`` hash =
    hash |> isValidHash =! false