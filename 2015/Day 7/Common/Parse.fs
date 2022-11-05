[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day7.Parse

open System
open FSharp.Text.RegexProvider

type SendInstructionRegex = Regex< @"(?<signal>\d+) -> (?<wire>[a-z]+)" >

type AndInstructionRegex =
    Regex< @"(?<in1>[a-z]+) AND (?<in2>[a-z]+) -> (?<out>[a-z]+)" >

type OrInstructionRegex =
    Regex< @"(?<in1>[a-z]+) OR (?<in2>[a-z]+) -> (?<out>[a-z]+)" >

type LShiftInstructionRegex =
    Regex< @"(?<in1>[a-z]+) LSHIFT (?<in2>[a-z]+) -> (?<out>[a-z]+)" >

type RShiftInstructionRegex =
    Regex< @"(?<in1>[a-z]+) RSHIFT (?<in2>[a-z]+) -> (?<out>[a-z]+)" >

type NotInstructionRegex = Regex< @"NOT (?<input>[a-z]+) -> (?<output>[a-z]+)" >

let private toSendPart s =
    SendInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let signal = Int32.Parse m.signal.Value
        let wire = m.wire.Value
        makeSend signal wire)

let private toAndPart s =
    AndInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let in1 = m.in1.Value
        let in2 = m.in2.Value
        let out = m.out.Value
        makeAnd in1 in2 out)

let private toOrPart s =
    OrInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let in1 = m.in1.Value
        let in2 = m.in2.Value
        let out = m.out.Value
        makeOr in1 in2 out)

let private toLShiftPart s =
    LShiftInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let in1 = m.in1.Value
        let in2 = m.in2.Value
        let out = m.out.Value
        makeLShift in1 in2 out)

let private toRShiftPart s =
    RShiftInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let in1 = m.in1.Value
        let in2 = m.in2.Value
        let out = m.out.Value
        makeRShift in1 in2 out)

let private toNotPart s =
    NotInstructionRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input = m.input.Value
        let output = m.output.Value
        makeNot input output)

let toPart s =
    [ toSendPart
      toAndPart
      toOrPart
      toLShiftPart
      toRShiftPart
      toNotPart ]
    |> List.tryPick (fun f -> f s)
