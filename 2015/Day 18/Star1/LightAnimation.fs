module AdventOfCode.Y2015.Day18.Star1.LightAnimation

let animateOnce grid =

    let nextLightState (x, y) light =
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
