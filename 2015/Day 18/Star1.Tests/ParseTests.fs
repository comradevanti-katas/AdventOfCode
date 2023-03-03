module AdventOfCode.Y2015.Day18.Star1.ParseTests

open System
open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``Can parse off light`` () =
    let parsed = Parse.tryLight '.'
    parsed =! Some offLight

[<Fact>]
let ``Can parse on light`` () =
    let parsed = Parse.tryLight '#'
    parsed =! Some onLight

[<Fact>]
let ``Cannot parse invalid string to light`` () =
    let parsed = Parse.tryLight 'x'
    parsed =! None

[<Fact>]
let ``Parsed grid has correct size`` () =
    let s = ".#" + Environment.NewLine + "#."
    let parsed = Parse.tryGrid s
    parsed |> Option.map gridSize =! Some 2

[<Fact>]
let ``Parsed grid has correct lights`` () =
    let s = ".#" + Environment.NewLine + "#."
    let parsed = Parse.tryGrid s

    parsed
    |> Option.iter (fun grid ->
        grid |> lightAt (0, 0) =! Some offLight
        grid |> lightAt (1, 0) =! Some onLight
        grid |> lightAt (0, 1) =! Some onLight
        grid |> lightAt (1, 1) =! Some offLight)
