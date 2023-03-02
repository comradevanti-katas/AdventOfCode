module AdventOfCode.Y2015.Day8.Star1.StringExtTests

open Xunit
open Swensen.Unquote

[<Theory>]
[<InlineData(@"""""", 2)>]
[<InlineData(@"""a""", 3)>]
[<InlineData(@"""hello""", 7)>]
let ``Surrounding quotes add to code-length`` s expected =
    let codeLength = s |> String.codeLength
    codeLength =! expected

[<Theory>]
[<InlineData(@"""\""""", 4)>]
[<InlineData(@"""a\""b""", 6)>]
let ``Quote-escaping \ add to code-length`` s expected =
    let codeLength = s |> String.codeLength
    codeLength =! expected

[<Theory>]
[<InlineData(@"""\x12""", 6)>]
[<InlineData(@"""hallo\xab""", 11)>]
let ``Unicode-escape-sequences add to code-length`` s expected =
    let codeLength = s |> String.codeLength
    codeLength =! expected

[<Theory>]
[<InlineData(@"""""", 0)>]
[<InlineData(@"""a""", 1)>]
[<InlineData(@"""hello""", 5)>]
let ``Surrounding quotes don't add to data-length`` s expected =
    let dataLength = s |> String.dataLength
    dataLength =! expected
    
[<Theory>]
[<InlineData(@"""\""""", 1)>]
[<InlineData(@"""\""a""", 2)>]
let ``Escaped quotes add 1 to data-length`` s expected =
    let dataLength = s |> String.dataLength
    dataLength =! expected
    
[<Theory>]
[<InlineData(@"""\\""", 1)>]
[<InlineData(@"""\\\""""", 2)>]
[<InlineData(@"""a\\b""", 3)>]
let ``Escaped back-slashes add 1 to data-length`` s expected =
    let dataLength = s |> String.dataLength
    dataLength =! expected

[<Theory>]
[<InlineData(@"""\xab""", 1)>]
[<InlineData(@"""\\\xab""", 2)>]
[<InlineData(@"""a\x12b""", 3)>]
let ``Escaped unicode-characters add 1 to data-length`` s expected =
    let dataLength = s |> String.dataLength
    dataLength =! expected
