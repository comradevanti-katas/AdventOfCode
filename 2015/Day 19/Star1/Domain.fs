[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day19.Star1.Domain

type Molecule = string

type Replacement = { From: Molecule; To: Molecule }

let (=>) x y = { From = x; To = y }
