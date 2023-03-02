[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day6.Domain

type XY = int * int

type Type =
    | TurnOn
    | TurnOff
    | Toggle

type Instruction = { Type: Type; From: XY; To: XY }
