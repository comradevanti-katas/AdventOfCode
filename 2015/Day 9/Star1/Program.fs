open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day9
open AdventOfCode.Y2015.Day9.Star1.Pathfinding

let private eval distances =
    let locations =
        distances
        |> List.map fst
        |> List.map locationsIn
        |> Set.unionMany

    let distanceByEndpoints = distances |> Map.ofList

    shortestPathLength locations distanceByEndpoints

let program =
    makeProgram
        allLines
        (parseEachWith Parse.toDistanceBetweenLocations)
        eval
        (fun distance -> $"The shortest distance is %d{distance}.")

[<EntryPoint>]
let main args = program args
