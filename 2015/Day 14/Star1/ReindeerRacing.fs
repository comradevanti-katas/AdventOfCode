module AdventOfCode.Y2015.Day14.Star1.ReindeerRacing

open AdventOfCode.Y2015.Day14.Reindeer

let private sliceOff i size =
    if size > i then (i, 0) else (size, i - size)

let rec distanceAfter time reindeer =
    if time <= 0 then
        0
    else
        let (flyTime, time) = sliceOff time (flyTimeOf reindeer)
        let (restTime, time) = sliceOff time (restTimeOf reindeer)
        let distance = flyTime * (speedOf reindeer)
        distance + (reindeer |> distanceAfter time)

let findTopDistance reindeer time =
    reindeer |> Seq.map (distanceAfter time) |> Seq.max
