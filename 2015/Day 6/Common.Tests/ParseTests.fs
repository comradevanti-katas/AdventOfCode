module AdventOfCode.Y2015.Day6.ParseTests

open Xunit
open Swensen.Unquote.Assertions

let private makeInstruction ``type`` from ``to`` =
    { Type = ``type``; From = from; To = ``to`` }

let parseableCases: obj array list =
    [ [| "turn on 0,0 through 999,999"
         makeInstruction On (0, 0) (999, 999) |]
      [| "toggle 0,0 through 999,0"
         makeInstruction Toggle (0, 0) (999, 0) |]
      [| "turn off 499,499 through 500,500"
         makeInstruction Off (499, 499) (500, 500) |] ]

let private cannotBeParsed s = s |> Parse.instruction =! None

let private parsesTo instruction s = s |> Parse.instruction =! Some instruction

[<Theory>]
[<InlineData("")>]
[<InlineData("uh oh")>]
[<InlineData("turn on 0;0 through 999;999")>]
[<InlineData("turn left 0,0 through 999,999")>]
let ``Strings that don't match the pattern cannot be parsed`` s =
    s |> cannotBeParsed

[<Theory>]
[<MemberData(nameof parseableCases)>]
let ``Strings that match pattern can be parsed`` s instruction =
    s |> parsesTo instruction
