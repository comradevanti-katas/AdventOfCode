module AdventOfCode.Y2015.Day18.Star1.LightAnimationTests

open Xunit
open LightAnimation
open Swensen.Unquote.Assertions

[<Fact>]
let ``On light with less than 2 on neighbors turns off`` () =
    let grid =
        gridOf
            [ [ offLight; offLight; offLight ]
              [ offLight; onLight; offLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some offLight

[<Fact>]
let ``On light with two on neighbors stays on`` () =
    let grid =
        gridOf
            [ [ offLight; offLight; onLight ]
              [ offLight; onLight; offLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some onLight

[<Fact>]
let ``On light with three on neighbors stays on`` () =
    let grid =
        gridOf
            [ [ offLight; onLight; onLight ]
              [ offLight; onLight; offLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some onLight

[<Fact>]
let ``On light with more than 3 on neighbors turns off`` () =
    let grid =
        gridOf
            [ [ onLight; onLight; offLight ]
              [ offLight; onLight; onLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some offLight

[<Fact>]
let ``Off light with less than 3 on neighbors stays off`` () =
    let grid =
        gridOf
            [ [ onLight; offLight; offLight ]
              [ offLight; offLight; offLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some offLight

[<Fact>]
let ``Off light with 3 on neighbors turns on`` () =
    let grid =
        gridOf
            [ [ onLight; offLight; onLight ]
              [ offLight; offLight; offLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some onLight

[<Fact>]
let ``Off light with more than 3 on neighbors stays off`` () =
    let grid =
        gridOf
            [ [ onLight; offLight; onLight ]
              [ offLight; offLight; onLight ]
              [ offLight; onLight; offLight ] ]

    grid |> animateOnce |> lightAt (1, 1) =! Some offLight