module AdventOfCode.Y2015.Day6.Star2.Light

open AdventOfCode.Y2015.Day6

type LightStrength = int

let private gridSize = 1000

let private make2DList w h value = List.replicate w (List.replicate h value)

let makeGrid size (strength: LightStrength) = make2DList size size strength

let baseGrid = makeGrid gridSize 0

let private mapInRange (x1, y1) (x2, y2) f grid =
    grid |> List.mapInRange y1 y2 (List.mapInRange x1 x2 f)

let tryGetLightAt (x, y) grid =
    grid |> List.tryItem y |> Option.bind (List.tryItem x)

let turnOn (strength: LightStrength) = strength + 1

let turnOff (strength: LightStrength) = max (strength - 1) 0

let toggle (strength: LightStrength) = strength + 2

let executeIn grid instruction =
    let updateFunc =
        match instruction.Type with
        | TurnOn -> turnOn
        | TurnOff -> turnOff
        | Toggle -> toggle

    grid
    |> mapInRange instruction.From instruction.To updateFunc

let totalBrightness (grid: LightStrength list list) =
    grid |> Seq.collect id |> Seq.sum
