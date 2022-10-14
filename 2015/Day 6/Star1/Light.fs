module AdventOfCode.Y2015.Day6.Star1.Light

open AdventOfCode.Y2015.Day6

type LightStatus =
    | On
    | Off

let private gridSize = 1000

let private make2DList w h value = List.replicate w (List.replicate h value)

let makeGrid size (status: LightStatus) = make2DList size size status

let baseGrid = makeGrid gridSize Off

let private mapInRange (x1, y1) (x2, y2) f grid =
    grid |> List.mapInRange y1 y2 (List.mapInRange x1 x2 f)

let tryGetLightAt (x, y) grid =
    grid |> List.tryItem y |> Option.bind (List.tryItem x)

let turnOn (_: LightStatus) = On

let turnOff (_: LightStatus) = Off

let toggle light = if light = On then Off else On

let executeIn grid instruction =
    let updateFunc =
        match instruction.Type with
        | TurnOn -> turnOn
        | TurnOff -> turnOff
        | Toggle -> toggle

    grid
    |> mapInRange instruction.From instruction.To updateFunc

let countLit grid = grid |> Seq.collect id |> Seq.filter ((=) On) |> Seq.length
