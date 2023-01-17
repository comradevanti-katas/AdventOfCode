[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day10.Domain

type Digit = int

type Block = { Digit: Digit; Count: int }

let private stringifySingle block =
    System.String.Concat(Seq.replicate block.Count block.Digit)

let stringify blocks =
    System.String.Concat(blocks |> Seq.map stringifySingle)
