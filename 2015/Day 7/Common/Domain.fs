[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day7.Domain

type WireId = string

type Signal = int

type Part =
    private
    | Send of (Signal * WireId)
    | And of (WireId * WireId * WireId)
    | Or of (WireId * WireId * WireId)
    | LShift of (WireId * WireId * WireId)
    | RShift of (WireId * WireId * WireId)
    | Not of (WireId * WireId)

let makeSend signal wire = Send(signal, wire)

let makeAnd in1 in2 out = And(in1, in2, out)

let makeOr in1 in2 out = Or(in1, in2, out)

let makeLShift in1 in2 out = LShift(in1, in2, out)

let makeRShift in1 in2 out = RShift(in1, in2, out)

let makeNot input output = Not(input, output)
