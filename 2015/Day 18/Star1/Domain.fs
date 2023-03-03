[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day18.Star1.Domain

type LightStatus =
    | On
    | Off

type Light = private Light of LightStatus

type LightGrid = private Lights of Light list list


let gridOf lights = Lights lights

let isOn (Light status) = status = On

let onLight = Light On

let offLight = Light Off

let toggle light =
    if light |> isOn then offLight else onLight

let gridSize (Lights lights) = lights |> List.length

let lightAt (x, y) (Lights lights) =
    lights |> List.tryItem y |> Option.bind (List.tryItem x)

let mapLight (x, y) f (Lights lights) =
    let row = lights |> List.item y
    let light = row |> List.item x
    lights |> List.updateAt y (row |> List.updateAt x (f light)) |> Lights


let onNeighborCountAt (x, y) grid =

    let isOnAt (x, y) =
        grid |> lightAt (x, y) |> Option.map isOn |> Option.defaultValue false

    let neighborPositions =
        seq {
            for dx in [ -1 .. 1 ] do
                for dy in [ -1 .. 1 ] do
                    if dx <> 0 || dy <> 0 then
                        yield (x + dx, y + dy)
        }

    neighborPositions |> Seq.filter isOnAt |> Seq.length

let positionsIn grid =
    let size = grid |> gridSize

    seq {
        for x in [ 0 .. size - 1 ] do
            for y in [ 0 .. size - 1 ] do
                yield (x, y)
    }

let onLightCount (Lights lights) =
    lights
    |> List.collect id
    |> List.filter isOn
    |> List.length