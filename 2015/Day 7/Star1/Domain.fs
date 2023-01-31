[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day7.Star1.Domain


type WireId = string

type Signal = uint16

type SignalSource =
    | Wire of WireId
    | Constant of Signal

type TransportGate = { Input: SignalSource; Output: WireId }

type AndGate =
    { Input: SignalSource * SignalSource
      Output: WireId }

type OrGate =
    { Input: SignalSource * SignalSource
      Output: WireId }

type LShiftGate =
    { Input: SignalSource
      Amount: int
      Output: WireId }

type RShiftGate =
    { Input: SignalSource
      Amount: int
      Output: WireId }

type NotGate = { Input: SignalSource; Output: WireId }

type Part =
    | TransportGate of TransportGate
    | AndGate of AndGate
    | OrGate of OrGate
    | LShiftGate of LShiftGate
    | RShiftGate of RShiftGate
    | NotGate of NotGate

let outputOf part =
    match part with
    | TransportGate gate -> gate.Output
    | AndGate gate -> gate.Output
    | OrGate gate -> gate.Output
    | LShiftGate gate -> gate.Output
    | RShiftGate gate -> gate.Output
    | NotGate gate -> gate.Output

let transport input output =
    TransportGate { Input = input; Output = output }

let andGate input1 input2 output =
    AndGate
        { Input = (input1, input2)
          Output = output }

let orGate input1 input2 output =
    OrGate
        { Input = (input1, input2)
          Output = output }

let lShiftGate input amount output =
    LShiftGate
        { Input = input
          Amount = amount
          Output = output }

let rShiftGate input amount output =
    RShiftGate
        { Input = input
          Amount = amount
          Output = output }

let notGate input output =
    NotGate { Input = input; Output = output }
