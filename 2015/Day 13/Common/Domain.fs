[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day13.Domain

type PersonName = string

type HappinessUnit = int

type Relation =
    { Person: PersonName
      Neighbor: PersonName
      Effect: HappinessUnit }
