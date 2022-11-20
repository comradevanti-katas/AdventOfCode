module AdventOfCode.Y2015.Day9.Star1.Pathfinding

open Microsoft.FSharp.Collections
open AdventOfCode.Y2015.Day9

let shortestPathLength locations (distances: Map<Endpoints, int>) =

    let distanceBetween endpoints = distances |> Map.find endpoints

    let lengthOf (Path endpoints) =
        endpoints |> List.map distanceBetween |> List.sum

    let paths =
        locations
        |> Set.toList
        |> List.permutations
        |> Seq.map makePath

    paths |> Seq.map lengthOf |> Seq.min
