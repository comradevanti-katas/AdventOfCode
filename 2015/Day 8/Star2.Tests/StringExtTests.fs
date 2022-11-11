module AdventOfCode.Y2015.Day8.Star2.StringExtTests

open Xunit
open Swensen.Unquote

[<Theory>]
[<InlineData(@"""""", @"""\""\""""")>]
[<InlineData(@"""abc""", @"""\""abc\""""")>]
let ``" gets encoded to \"`` s expected =
    let encoded = s |> String.encode
    encoded =! expected
    
[<Theory>]
[<InlineData(@"""aaa\""aaa""", @"""\""aaa\\\""aaa\""""")>]
[<InlineData(@"""\xab""", @"""\""\\xab\""""")>]
let ``\ gets encoded to \\`` s expected =
    let encoded = s |> String.encode
    encoded =! expected