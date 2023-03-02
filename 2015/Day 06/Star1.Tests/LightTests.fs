module AdventOfCode.Y2015.Day6.Star1.LightTests

open FsCheck.Xunit
open Xunit
open AdventOfCode.Y2015.Day6
open AdventOfCode.Y2015.Day6.Star1.Light
open Swensen.Unquote.Assertions

[<Fact>]
let ``The base-grid is 1000x1000`` () =
    let width = baseGrid |> List.head |> List.length
    let height = baseGrid |> List.length

    width =! 1000
    height =! 1000

[<Fact>]
let ``The base-grid is all off`` () =
    let all = baseGrid |> List.collect id
    all |> List.forall ((=) Off) =! true

[<Property>]
let ``Turning a light on turns it on regardless of prior status`` prior =
    prior |> turnOn =! On

[<Property>]
let ``Turning a light off turns it off regardless of prior status`` prior =
    prior |> turnOff =! Off

[<Property>]
let ``Toggling a light flips its status`` prior =
    let flipped = if prior = On then Off else On
    prior |> toggle =! flipped

[<Fact>]
let ``Turning the whole range on turns all lights on`` () =
    let instruction =
        { Type = TurnOn; From = (0, 0); To = (999, 999) }

    let grid = instruction |> executeIn baseGrid
    grid |> List.collect id |> List.forall ((=) On) =! true
