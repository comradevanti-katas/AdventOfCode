module AdventOfCode.Y2015.Day9.ParseTests

open Xunit
open Swensen.Unquote
open AdventOfCode.Y2015.Day9

[<Theory>]
[<InlineData("London to Dublin = 464", "London", "Dublin", 464)>]
[<InlineData("London to Belfast = 518", "London", "Belfast", 518)>]
[<InlineData("Dublin to Belfast = 141", "Dublin", "Belfast", 141)>]
let ``Valid lines can be parsed`` line a b distance =
    let parsed = Parse.toDistanceBetweenLocations line
    parsed =! Some(between a b, distance)
