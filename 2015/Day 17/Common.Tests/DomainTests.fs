module AdventOfCode.Y2015.Day17.DomainTests

open Xunit
open AdventOfCode.Y2015.Day17
open Swensen.Unquote.Assertions

[<Fact>]
let ``Combinations are found correctly`` () =
    let containers =
        [ { Id = 1u; Capacity = 20u }
          { Id = 2u; Capacity = 15u }
          { Id = 3u; Capacity = 10u }
          { Id = 4u; Capacity = 5u }
          { Id = 5u; Capacity = 5u } ]

    let combinations = containers |> combinationsFor 25u
    combinations =! Set.ofList [
        Set.ofList [ 2u; 3u ]
        Set.ofList [ 1u; 4u ]
        Set.ofList [ 1u; 5u ]
        Set.ofList [ 2u; 4u; 5u ]
    ]
