module AdventOfCode.Y2015.Day12.Star2.JSONValidationTests

open AdventOfCode.Y2015.Day12.Star2.JSONValidation
open Swensen.Unquote.Assertions
open Xunit

[<Theory>]
[<InlineData("[1,2,3]", 6)>]
[<InlineData("[1,{\"c\":\"red\",\"b\":2},3]", 4)>]
[<InlineData("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)>]
[<InlineData("[1,\"red\",5]", 6)>]
[<InlineData("[{\"a\":1},{\"b\":\"red\"}]", 1)>]
let ``Sums are counted correctly`` json sum = sumIn json =! sum
