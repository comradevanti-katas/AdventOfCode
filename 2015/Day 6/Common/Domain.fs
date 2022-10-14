[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day6.Domain

type XY = int * int

type Type =
    | On
    | Off
    | Toggle

type Instruction = { Type: Type; From: XY; To: XY }
