module AdventOfCode.Y2015.Day3.Star1.SleighTests

open System.Collections.Generic
open FsCheck
open FsCheck.Xunit
open global.Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day3

let private isAtLeast1 x = x >= 1

let private is1 x = x = 1

let private presentCount (kv: KeyValuePair<_, _>) = kv.Value

let private house (kv: KeyValuePair<_, _>) = kv.Key


[<Property>]
let ``Total number of presents is direction-count + 1`` directions =
    let directionCount = directions |> List.length
    let presentsByHouse = Sleigh.follow directions
    let totalPresents = presentsByHouse |> Seq.sumBy presentCount
    totalPresents =! directionCount + 1

[<Property>]
let ``Visited houses get 1 or more presents`` directions =
    let presentsByHouse = Sleigh.follow directions
    presentsByHouse |> Seq.forall (presentCount >> isAtLeast1)

[<Fact>]
let ``Not moving delivers 1 present to the origin`` () =
    let directions = []
    let presentsByHouse = Sleigh.follow directions
    let expected = Map.ofSeq [ (Sleigh.origin, 1) ]
    presentsByHouse =! expected

[<Property>]
let ``Going in straight line visits each house once``
    direction
    (PositiveInt count)
    =
    let directions = List.replicate count direction
    let presentsByHouse = Sleigh.follow directions
    presentsByHouse |> Seq.forall (presentCount >> is1)

[<Fact>]
let ``Visiting a house for the first time gives 1 present`` () =
    let directions = [ Up ]
    let presentsByHouse = Sleigh.follow directions
    let expected = Map.ofSeq [ (Sleigh.origin, 1); (0, 1), 1 ]
    presentsByHouse =! expected

[<Fact>]
let ``Visiting a house repeatedly time gives 1 present each time`` () =
    let directions = [ Up; Down ]
    let presentsByHouse = Sleigh.follow directions
    let expected = Map.ofSeq [ (Sleigh.origin, 2); (0, 1), 1 ]
    presentsByHouse =! expected
