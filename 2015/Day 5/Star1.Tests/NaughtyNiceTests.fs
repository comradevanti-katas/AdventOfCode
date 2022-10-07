module AdventOfCode.Y2015.Day5.Star1.NaughtyNiceTests

open Xunit
open AdventOfCode.Y2015.Day5.Star1.NaughtyNice
open Swensen.Unquote.Assertions

let private shouldBeNice s = isNice s =! true

let private shouldNotBeNice s = isNice s =! false

[<Theory>]
[<InlineData("aa")>]
[<InlineData("aebb")>]
[<InlineData("irre")>]
let ``Nice strings must contain at least 3 vowels`` s = s |> shouldNotBeNice

[<Theory>]
[<InlineData("aio")>]
[<InlineData("wowowai")>]
[<InlineData("uiaro")>]
let ``Nice strings must contain a letter twice in a row`` s =
    s |> shouldNotBeNice

[<Fact>]
let ``Nice strings may not contain "ab"`` () = "abioo" |> shouldNotBeNice

[<Fact>]
let ``Nice strings may not contain "cd"`` () = "cdaioo" |> shouldNotBeNice

[<Fact>]
let ``Nice strings may not contain "pq"`` () = "pqaioo" |> shouldNotBeNice

[<Fact>]
let ``Nice strings may not contain "xy"`` () = "xyaioo" |> shouldNotBeNice

[<Theory>]
[<InlineData("ugknbfddgicrmopn")>]
[<InlineData("aaiioo")>]
[<InlineData("yeyayoo")>]
let ``Strings which don't break any rules are nice`` s = s |> shouldBeNice
