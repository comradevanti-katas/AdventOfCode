﻿module AdventOfCode.Y2015.Day18.Star2.LightAnimation

open AdventOfCode.Y2015.Day18

let animateOnce grid =

    let size = gridSize grid
    let maxIndex = size - 1

    let cornerXYs =
        Set.ofList
            [ (0, 0); (0, maxIndex); (maxIndex, 0); (maxIndex, maxIndex) ]

    let isCorner (x, y) = cornerXYs |> Set.contains (x, y)

    let nextLightState (x, y) light =
        if isCorner (x, y) then
            onLight
        else
            let litNeighbors = grid |> onNeighborCountAt (x, y)

            if light = onLight then
                if litNeighbors = 2 || litNeighbors = 3 then
                    onLight
                else
                    offLight
            else if litNeighbors = 3 then
                onLight
            else
                offLight

    let updateAt grid (x, y) =
        grid |> mapLight (x, y) (nextLightState (x, y))

    positionsIn grid |> Seq.fold updateAt grid

let rec animateTimes x grid =
    if x = 0 then
        grid
    else
        grid |> animateOnce |> animateTimes (x - 1)
