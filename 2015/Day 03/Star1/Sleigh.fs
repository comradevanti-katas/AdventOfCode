[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day3.Star1.Sleigh

open AdventOfCode.Y2015.Day3

let origin = (0, 0)

let private deliverPresentTo house presentsPerHouse =
    presentsPerHouse
    |> Map.change house (function
        | Some presentCount -> Some(presentCount + 1)
        | None -> Some 1)

let private move direction house =
    let x, y = house

    match direction with
    | Up -> (x, y + 1)
    | Right -> (x + 1, y)
    | Down -> (x, y - 1)
    | Left -> (x - 1, y)

let rec private followFrom currentHouse directions presentsByHouse =
    match directions with
    | direction :: remaining ->
        let nextHouse = currentHouse |> move direction

        presentsByHouse
        |> deliverPresentTo nextHouse
        |> followFrom nextHouse remaining
    | [] -> presentsByHouse

let follow directions =
    Map.empty
    |> deliverPresentTo origin
    |> followFrom origin directions
