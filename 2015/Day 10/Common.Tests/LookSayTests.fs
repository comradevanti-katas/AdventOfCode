module AdventOfCode.Y2015.Day10.LookSayTests

open Xunit
open AdventOfCode.Y2015.Day10
open LookSay

[<Theory>]
[<InlineData("1", "11")>]
[<InlineData("11", "21")>]
[<InlineData("21", "1211")>]
[<InlineData("1211", "111221")>]
[<InlineData("111221", "312211")>]
[<InlineData("1113122113", "311311222113")>]
let ``Sequences expand correctly`` (s: string) expected =
    let blocks = s |> Parse.tryBlockSequence |> Option.get
    let expanded = blocks |> lookSay |> stringify

    Assert.Equal(expected, expanded)
