module AdventOfCode.Y2015.Day7.Star1.CircuitTests

open FsCheck.Xunit
open global.Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day7

[<Property>]
let ``Transports copy constant signals without change`` signal =
    let circuit = Circuit.makeFrom [ transport (Constant signal) "a" ]
    (circuit |> Circuit.trySignalOn "a") =! Some signal

[<Property>]
let ``Transports copy wire signals without change`` signal =
    let circuit =
        Circuit.makeFrom
            [ transport (Constant signal) "a"; transport (Wire "a") "b" ]

    (circuit |> Circuit.trySignalOn "b") =! Some signal


[<Fact>]
let ``And-gates bitwise AND their inputs`` () =
    let circuit =
        Circuit.makeFrom [ andGate (Constant 123us) (Constant 456us) "a" ]

    (circuit |> Circuit.trySignalOn "a") =! Some 72us

[<Fact>]
let ``Or-gates bitwise OR their inputs`` () =
    let circuit =
        Circuit.makeFrom [ orGate (Constant 123us) (Constant 456us) "a" ]

    (circuit |> Circuit.trySignalOn "a") =! Some 507us

[<Fact>]
let ``Left-shift-gates bitwise shift their input left`` () =
    let circuit = Circuit.makeFrom [ lShiftGate (Constant 123us) 2 "a" ]

    (circuit |> Circuit.trySignalOn "a") =! Some 492us

[<Fact>]
let ``Right-shift-gates bitwise shift their input right`` () =
    let circuit = Circuit.makeFrom [ rShiftGate (Constant 456us) 2 "a" ]

    (circuit |> Circuit.trySignalOn "a") =! Some 114us

[<Fact>]
let ``Not-gates bitwise invert their input`` () =
    let circuit = Circuit.makeFrom [ notGate (Constant 123us) "a" ]

    (circuit |> Circuit.trySignalOn "a") =! Some 65412us
