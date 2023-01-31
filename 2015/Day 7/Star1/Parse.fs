[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day7.Star1.Parse

open System.Text.RegularExpressions
open FSharp.Text.RegexExtensions
open FSharp.Text.RegexProvider

type TransportGateRegex =
    Regex< @"^(?<input>\d+|[a-z]+) -> (?<output>[a-z]+)$" >

type AndGateRegex =
    Regex< @"^(?<input1>\d+|[a-z]+) AND (?<input2>\d+|[a-z]+) -> (?<output>[a-z]+)$" >

type OrGateRegex =
    Regex< @"^(?<input1>\d+|[a-z]+) OR (?<input2>\d+|[a-z]+) -> (?<output>[a-z]+)$" >

type LShiftGateRegex =
    Regex< @"^(?<input>\d+|[a-z]+) LSHIFT (?<amount>\d+) -> (?<output>[a-z]+)$" >

type RShiftGateRegex =
    Regex< @"^(?<input>\d+|[a-z]+) RSHIFT (?<amount>\d+) -> (?<output>[a-z]+)$" >

type NotGateRegex = Regex< @"^NOT (?<input>\d+|[a-z]+) -> (?<output>[a-z]+)$" >

let private toSource (group: Group) =
    match group.TryAsUInt16 with
    | Some signal -> (Constant signal)
    | None -> Wire group.Value

let private toTransportGate s =
    TransportGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input = m.input |> toSource
        let wire = m.output.Value
        transport input wire)

let private toAndGate s =
    AndGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input1 = m.input1 |> toSource
        let input2 = m.input2 |> toSource
        let wire = m.output.Value
        andGate input1 input2 wire)

let private toOrGate s =
    OrGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input1 = m.input1 |> toSource
        let input2 = m.input2 |> toSource
        let wire = m.output.Value
        orGate input1 input2 wire)

let private toLShiftGate s =
    LShiftGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input = m.input |> toSource
        let amount = m.amount.AsInt
        let wire = m.output.Value
        lShiftGate input amount wire)

let private toRShiftGate s =
    RShiftGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input = m.input |> toSource
        let amount = m.amount.AsInt
        let wire = m.output.Value
        rShiftGate input amount wire)

let private toNotGate s =
    NotGateRegex().TryTypedMatch s
    |> Option.map (fun m ->
        let input = m.input |> toSource
        let wire = m.output.Value
        notGate input wire)

let toPart s =
    [ toTransportGate
      toAndGate
      toOrGate
      toLShiftGate
      toRShiftGate
      toNotGate ]
    |> List.tryPick (fun f -> f s)
