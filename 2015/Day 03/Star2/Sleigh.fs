[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day3.Star2.Sleigh

open AdventOfCode.Y2015.Day3.Star1

let private merge map1 map2 =
    let add map house presentCount =
        map
        |> Map.change house (function
            | Some original -> Some(original + presentCount)
            | None -> Some presentCount)

    map2 |> Map.fold add map1

let rec private alternate list =
    list
    |> List.chunkBySize 2
    |> List.map (function
        | [a; b] -> (a, b)
        | _ -> failwith "oof")
    |> List.unzip
    

let followWithRobo directions =
    let santaDirections, roboDirections = directions |> alternate
    let santaPresentsByHouse = Sleigh.follow santaDirections
    let roboPresentsByHouse = Sleigh.follow roboDirections

    merge santaPresentsByHouse roboPresentsByHouse
