module AdventOfCode.Y2015.Day1.ParseTests

open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``( is parsed as Up`` () =
    let direction = Parse.single '('
    direction =! Some Up
    
[<Fact>]
let ``) is parsed as Down`` () =
    let direction = Parse.single ')'
    direction =! Some Down
    
[<Theory>]
[<InlineData('a')>]
[<InlineData('/')>]
[<InlineData('x')>]
[<InlineData('!')>]
[<InlineData('3')>]
let ``Characters other than ( and ) cannot be parsed`` c =
    let direction = Parse.single c
    direction =! None