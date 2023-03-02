module AdventOfCode.Y2015.Day1.Star1.FloorTests

open Swensen.Unquote.Assertions
open Xunit
open AdventOfCode.Y2015.Day1
open AdventOfCode.Y2015.Day1.Star1.Floor

[<Fact>]
let ``Up increases floor by one`` () =
    let floor = 1

    let newFloor = moveFrom floor Up

    newFloor =! 2

[<Fact>]
let ``Down decreases floor by one`` () =
    let floor = 3

    let newFloor = moveFrom floor Down

    newFloor =! 2

[<Theory>]
[<InlineData("(())", 0)>]
[<InlineData("()()", 0)>]
[<InlineData("(((", 3)>]
[<InlineData("(()(()(", 3)>]
[<InlineData("))(((((", 3)>]
[<InlineData("())", -1)>]
[<InlineData("))(", -1)>]
[<InlineData(")))", -3)>]
[<InlineData(")())())", -3)>]
let ``Directions lead to correct floor`` input expectedFloor =
    let floor =
        input |> Parse.sequence |> Option.map followDirections

    floor =! Some expectedFloor
