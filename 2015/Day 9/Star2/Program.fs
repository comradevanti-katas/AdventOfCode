open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day9
open AdventOfCode.Y2015.Day9.Star2.Pathfinding

let private eval distances =
    let locations =
        distances
        |> List.map fst
        |> List.map locationsIn
        |> Set.unionMany

    let distanceByEndpoints = distances |> Map.ofList

    longestPathLength locations distanceByEndpoints

let program =
    makeProgram
        allLines
        (parseEachWith Parse.toDistanceBetweenLocations)
        eval
        (fun distance -> $"The longest distance is %d{distance}.")

[<EntryPoint>]
let main args = program args
