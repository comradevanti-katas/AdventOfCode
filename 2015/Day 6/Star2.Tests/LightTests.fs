module AdventOfCode.Y2015.Day6.Star2.LightTests

open FsCheck
open FsCheck.Xunit
open global.Xunit
open AdventOfCode.Y2015.Day6
open AdventOfCode.Y2015.Day6.Star2.Light
open Swensen.Unquote.Assertions

[<Fact>]
let ``The base-grid is 1000x1000`` () =
    let width = baseGrid |> List.head |> List.length
    let height = baseGrid |> List.length

    width =! 1000
    height =! 1000

[<Fact>]
let ``The base-grid is all strength 0`` () =
    let all = baseGrid |> List.collect id
    all |> List.forall ((=) 0) =! true


[<Property>]
let ``Turning a light on increases its strength by 1`` strength =
    strength |> turnOn =! (strength + 1)

[<Property>]
let ``Turning a light off decreases its strength by 1 ``
    (PositiveInt strength)
    =
    (strength > 0)
    ==> lazy (strength |> turnOff =! (strength - 1))

[<Fact>]
let ``Cannot decrease to negative numbers`` () = 0 |> turnOff =! 0

[<Property>]
let ``Toggling a light increases its strength by 2 `` strength =
    strength |> toggle =! (strength + 2)
