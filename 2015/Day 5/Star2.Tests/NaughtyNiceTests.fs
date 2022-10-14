module AdventOfCode.Y2015.Day5.Star2.NaughtyNiceTests

open Xunit
open AdventOfCode.Y2015.Day5.Star2.NaughtyNice
open Swensen.Unquote.Assertions

let private shouldBeNice s = isNice s =! true

let private shouldNotBeNice s = isNice s =! false

[<Theory>]
[<InlineData("aaa")>]
[<InlineData("aaxoo")>]
[<InlineData("abcrxr")>]
[<InlineData("ieodomkazucvgmuy")>]
let ``Nice strings have two non-overlapping pairs`` s = s |> shouldNotBeNice

[<Theory>]
[<InlineData("aahjaxja")>]
[<InlineData("aooaxoo")>]
[<InlineData("aabcrxlaa")>]
[<InlineData("uurcxstgmygtbstg")>]
let ``Nice strings have a letter twice with any single letter between`` s =
    s |> shouldNotBeNice

[<Theory>]
[<InlineData("qjhvhtzxzqqjkmpb")>]
[<InlineData("xxyxx")>]
[<InlineData("erssdjfsflkjijss")>]
let ``Strings that don't break any rules are nice`` s = s |> shouldBeNice
