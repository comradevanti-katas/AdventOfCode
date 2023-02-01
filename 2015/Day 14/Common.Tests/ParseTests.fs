module AdventOfCode.Y2015.Day14.ParseTests

open Xunit
open AdventOfCode.Y2015.Day14.Reindeer
open Swensen.Unquote.Assertions

[<Fact>]
let ``Valid reindeer can be parsed`` () =
    let s =
        "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds."

    let expected = reindeer "Comet" 14 10 127
    s |> Parse.toReindeer =! Some expected
