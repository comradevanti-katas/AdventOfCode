﻿module AdventOfCode.Y2015.Day14.Star1.ReindeerTests

open Xunit
open AdventOfCode.Y2015.Day14.Star1.Reindeer
open Swensen.Unquote.Assertions

[<TheoryAttribute>]
[<InlineData(14, 10, 127, 1, 14)>]
[<InlineData(14, 10, 127, 10, 140)>]
[<InlineData(14, 10, 127, 11, 140)>]
[<InlineData(14, 10, 127, 1000, 1120)>]
[<InlineData(16, 11, 162, 1, 16)>]
[<InlineData(16, 11, 162, 10, 160)>]
[<InlineData(16, 11, 162, 11, 176)>]
[<InlineData(16, 11, 162, 1000, 1056)>]
let ``Distance is calculated correctly``
    speed
    flyTime
    restTime
    raceTime
    expected
    =
    let reindeer = reindeer speed flyTime restTime
    let distance = reindeer |> raceFor raceTime
    distance =! expected

[<Fact>]
let ``Can find the top distance`` () =
    let comet = reindeer 14 10 127
    let dancer = reindeer 16 11 162
    let topDistance = findTopDistance [ comet; dancer ] 1000
    topDistance =! 1120
