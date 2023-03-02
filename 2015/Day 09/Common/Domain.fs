[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day9.Domain

type Location = string

type Endpoints = private Endpoints of Set<Location>

type Path = Path of Endpoints list

let between a b = Endpoints(Set.ofList [ a; b ])

let locationsIn (Endpoints locations) = locations

let makePath locations =
    locations
    |> List.pairwise
    |> List.map (fun (a, b) -> between a b)
    |> Path