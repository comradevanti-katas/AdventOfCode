module AdventOfCode.Y2015.Day9.Star1.Pathfinding

open Microsoft.FSharp.Collections

type Location = string

type Endpoints = private Endpoints of Set<Location>

type Path = Path of Endpoints list


let rec private allCombinations list =
    let rec inserts e =
        function
        | [] -> [ [ e ] ]
        | x :: xs as list->
            (e :: list)
            :: (inserts e xs |> List.map (fun xs' -> x :: xs'))

    let addIntoEvery lists x = lists |> List.collect (inserts x)

    list |> List.fold addIntoEvery [ [] ]

let between a b = Endpoints(Set.ofList [ a; b ])

let rec locationsIn (Endpoints locations) = locations


let private makePath locations =
    locations
    |> List.pairwise
    |> List.map (fun (a, b) -> between a b)
    |> Path

let shortestPathLength locations (distances: Map<Endpoints, int>) =

    let distanceBetween endpoints = distances |> Map.find endpoints

    let lengthOf (Path endpoints) =
        endpoints |> List.map distanceBetween |> List.sum

    let paths =
        locations
        |> Set.toList
        |> allCombinations
        |> Seq.map makePath

    paths |> Seq.map lengthOf |> Seq.min
