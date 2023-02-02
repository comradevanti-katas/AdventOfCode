[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day16.Domain

type Compound = string

type Amount = int

type CompoundTable = Map<Compound, Amount>

type Sue =
    { Number: int
      Compounds: CompoundTable }

let makeSue number compounds =
    { Number = number
      Compounds = Map.ofSeq compounds }
