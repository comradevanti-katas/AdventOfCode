module AdventOfCode.Y2015.Day3.ParseTests

open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``^ is Up`` () = Parse.direction '^' =! Some Up

[<Fact>]
let ``> is Right`` () = Parse.direction '>' =! Some Right

[<Fact>]
let ``v is Down`` () = Parse.direction 'v' =! Some Down

[<Fact>]
let ``< is Left`` () = Parse.direction '<' =! Some Left

[<Theory>]
[<InlineData(' ')>]
[<InlineData('/')>]
[<InlineData('x')>]
[<InlineData('5')>]
let ``Other character cannot be parsed as directions`` c =
    Parse.direction c =! None

[<Fact>]
let ``Multiple can be parsed if each individual can be parsed`` () =
    let s = "^<v>"
    let directions = Parse.directions s
    directions =! Some [ Up; Left; Down; Right ]

[<Fact>]
let ``Multiple cannot be parsed if any individual cannot be parsed`` () =
    let s = "^<x>"
    let directions = Parse.directions s
    directions =! None
