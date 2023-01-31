namespace AdventOfCode.Y2015.Day7.Star1

open AdventOfCode
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core

type Circuit = private Circuit of Map<WireId, Part>

[<RequireQualifiedAccess>]
module Circuit =

    let trySignalOn wire (Circuit partsByOutput) =

        let mutable signalCache = Map.empty

        let cacheSignal wire signal =
            signalCache <- signalCache |> Map.add wire signal

        let rec trySignalOn' wire =

            let sourceSignalOf source =
                match source with
                | Wire wire ->
                    match signalCache |> Map.tryFind wire with
                    | Some signal -> Some signal
                    | None -> trySignalOn' wire
                | Constant signal -> Some signal

            let unaryOp source f = sourceSignalOf source |> Option.map f

            let binaryOp sources f =
                let (source1, source2) = sources

                sourceSignalOf source1
                |> Option.bind (fun signal1 ->
                    sourceSignalOf source2 |> Option.map (f signal1))

            let result =
                partsByOutput
                |> Map.tryFind wire
                |> Option.bind (fun part ->
                    match part with
                    | TransportGate gate -> unaryOp gate.Input id
                    | AndGate gate -> binaryOp gate.Input (&&&)
                    | OrGate gate -> binaryOp gate.Input (|||)
                    | LShiftGate gate ->
                        unaryOp gate.Input (fun signal -> signal <<< gate.Amount)
                    | RShiftGate gate ->
                        unaryOp gate.Input (fun signal -> signal >>> gate.Amount)
                    | NotGate gate -> unaryOp gate.Input (~~~))

            result |> Option.iter (cacheSignal wire)
            result

        trySignalOn' wire

    let makeFrom parts =
        (Map.empty, parts)
        ||> Seq.fold (fun partsByOutput part ->
            partsByOutput |> Map.add (outputOf part) part)
        |> Circuit
