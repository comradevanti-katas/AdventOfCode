[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day17.Domain

open Microsoft.FSharp.Collections

type Liters = uint

type ContainerId = uint

type Container = { Id: ContainerId; Capacity: Liters }

let private containerIds combination =
    combination |> Set.map (fun container -> container.Id)

let private totalCapacity combination =
    combination |> Seq.map (fun container -> container.Capacity) |> Seq.sum

let rec private allCombinations list =
    match list with
    | [] -> Seq.singleton Set.empty
    | head :: tail ->
        allCombinations tail
        |> Seq.collect (fun combination ->
            seq {
                yield combination
                yield (combination |> Set.add head)
            })

let combinationsFor liters allContainers =
    let combinations = allContainers |> allCombinations

    let validCombinations =
        combinations |> Seq.filter (totalCapacity >> (=) liters)

    validCombinations |> Seq.map containerIds |> Set.ofSeq
