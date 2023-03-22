module AdventOfCode.Y2015.Day19.Star1.CalibrationTests

open Xunit
open Swensen.Unquote.Assertions
open Calibration

[<Fact>]
let ``H2O with H => OO becomes OO2O`` () =
    let molecule = "H2O"
    let replacements = Set.ofList [ "H" => "OO" ]
    let expected = Set.singleton "OO2O"
    calibrate replacements molecule =! expected

[<Fact>]
let ``HOH with H => HO becomes HOOH and HOHO`` () =
    let molecule = "HOH"
    let replacements = Set.ofList [ "H" => "HO" ]
    let expected = Set.ofList [ "HOOH"; "HOHO" ]
    calibrate replacements molecule =! expected

[<Fact>]
let ``HOH with H => OH becomes HOOH and OHOH`` () =
    let molecule = "HOH"
    let replacements = Set.ofList [ "H" => "OH" ]
    let expected = Set.ofList [ "HOOH"; "OHOH" ]
    calibrate replacements molecule =! expected

[<Fact>]
let ``HOH with O => HH becomes HHHH`` () =
    let molecule = "HOH"
    let replacements = Set.ofList [ "O" => "HH" ]
    let expected = Set.ofList [ "HHHH" ]
    calibrate replacements molecule =! expected

[<Fact>]
let ``Correct number of distinct molecules is found`` () =
    let molecule = "HOHOHO"
    let replacements = Set.ofList [ "H" => "HO"; "H" => "OH"; "O" => "HH" ]
    let expected = 7
    calibrate replacements molecule |> Set.count =! expected
