open AdventOfCode.AdventProgram
open AdventOfCode.Y2015.Day13

let private eval relations =
    let map = NeighborEffectMap.makeFrom relations
    SeatingArrangement.calcMaximumHappinessFor map

let private makeMsg happiness =
    $"The maximum happiness is %i{happiness}"

let private program =
    makeProgram allLines (parseEachWith Parse.tryRelation) eval makeMsg

[<EntryPoint>]
let main args = program args
