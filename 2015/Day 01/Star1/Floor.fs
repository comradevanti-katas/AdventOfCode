module AdventOfCode.Y2015.Day1.Star1.Floor

open AdventOfCode.Y2015.Day1

let moveFrom floor direction =
    match direction with
    | Up -> floor + 1
    | Down -> floor - 1
    
let followDirections directions =
    directions
    |> Seq.fold moveFrom 0