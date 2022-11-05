module AdventOfCode.Y2015.Day7.ParseTests

open Xunit
open Swensen.Unquote.Assertions

[<Theory>]
[<InlineData("123 -> x", 123, "x")>]
[<InlineData("456 -> y", 456, "y")>]
[<InlineData("5 -> abc", 5, "abc")>]
let ``Can parse send-parts of correct format`` s signal wire =
    let expected = Some(makeSend signal wire)
    let actual = s |> Parse.toPart
    actual =! expected

[<Theory>]
[<InlineData("x AND y -> z", "x", "y", "z")>]
[<InlineData("ab AND cd -> ef", "ab", "cd", "ef")>]
let ``Can parse and-parts of correct format`` s in1 in2 out =
    let expected = Some(makeAnd in1 in2 out)
    let actual = s |> Parse.toPart
    actual =! expected
    
    
[<Theory>]
[<InlineData("x OR y -> z", "x", "y", "z")>]
[<InlineData("ab OR cd -> ef", "ab", "cd", "ef")>]
let ``Can parse or-parts of correct format`` s in1 in2 out =
    let expected = Some(makeOr in1 in2 out)
    let actual = s |> Parse.toPart
    actual =! expected
    
[<Theory>]
[<InlineData("x LSHIFT y -> z", "x", "y", "z")>]
[<InlineData("ab LSHIFT cd -> ef", "ab", "cd", "ef")>]
let ``Can parse left-shift-parts of correct format`` s in1 in2 out =
    let expected = Some(makeLShift in1 in2 out)
    let actual = s |> Parse.toPart
    actual =! expected

[<Theory>]
[<InlineData("x RSHIFT y -> z", "x", "y", "z")>]
[<InlineData("ab RSHIFT cd -> ef", "ab", "cd", "ef")>]
let ``Can parse right-shift-parts of correct format`` s in1 in2 out =
    let expected = Some(makeRShift in1 in2 out)
    let actual = s |> Parse.toPart
    actual =! expected
    
[<Theory>]
[<InlineData("NOT x -> y", "x", "y")>]
[<InlineData("NOT ab -> cd", "ab", "cd")>]
let ``Can parse not-parts of correct format`` s input output =
    let expected = Some(makeNot input output)
    let actual = s |> Parse.toPart
    actual =! expected

[<Theory>]
[<InlineData("123 -> 123")>]
[<InlineData("a -> y")>]
[<InlineData("5-> abc")>]
[<InlineData("1 AND y -> z")>]
[<InlineData("ab AND cd -> 12")>]
[<InlineData("ab ANDcd -> ef")>]
[<InlineData("ab OR  cd -> ef")>]
[<InlineData("a OI b -> c")>]
let ``Cannot parse parts of incorrect format`` s =
    let expected = None
    let actual = s |> Parse.toPart
    actual =! expected
