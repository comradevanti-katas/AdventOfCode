module AdventOfCode.Y2015.Day14.Star2.ReindeerRacingTests

open Xunit
open AdventOfCode.Y2015.Day14.Reindeer
open AdventOfCode.Y2015.Day14.Star2.ReindeerRacing
open Swensen.Unquote.Assertions

[<Fact>]
let ``Points are calculated correctly`` () =
    let comet = reindeer "Comet" 14 10 127
    let dancer = reindeer "Dancer" 16 11 162
    let pointsByName = [ comet; dancer ] |> raceForPoints 1000
    pointsByName |> Map.find "Comet" =! 312
    pointsByName |> Map.find "Dancer" =! 689

[<Fact>]
let ``Can find winner points`` () =
    let comet = reindeer "Comet" 14 10 127
    let dancer = reindeer "Dancer" 16 11 162
    winnerPoints [ comet; dancer ] 1000 =! 689
