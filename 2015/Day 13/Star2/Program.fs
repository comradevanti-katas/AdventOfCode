open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day13

let private addMe map =

    let addRelationWithMe map person =
        map
        |> NeighborEffectMap.add
            { Person = "Me"
              Neighbor = person
              Effect = 0 }
        |> NeighborEffectMap.add
            { Person = person
              Neighbor = "Me"
              Effect = 0 }

    let people = NeighborEffectMap.peopleIn map
    (map, people) ||> Seq.fold addRelationWithMe

let private eval relations =
    let map = NeighborEffectMap.makeFrom relations |> addMe
    SeatingArrangement.calcMaximumHappinessFor map

let private makeMsg happiness =
    $"The maximum happiness is %i{happiness}"

let private program =
    makeProgram allLines (parseEachWith Parse.tryRelation) eval makeMsg

[<EntryPoint>]
let main args = program args
