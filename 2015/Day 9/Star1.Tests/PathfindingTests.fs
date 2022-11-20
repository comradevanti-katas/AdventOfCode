module AdventOfCode.Y2015.Day9.Star1.PathfindingTests

open global.Xunit
open Swensen.Unquote
open AdventOfCode.Y2015.Day9.Star1.Pathfinding

let private london = "London"
let private dublin = "Dublin"
let private belfast = "Belfast"
let private locations = Set.ofList [ london; dublin; belfast ]

let private distances =
    Map.ofList [ (between london dublin, 464)
                 (between london belfast, 518)
                 (between dublin belfast, 141) ]


[<Fact>]
let ``The found distance is the shortest one`` () =
    let distance = shortestPathLength locations distances
    distance =! 605
