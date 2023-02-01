module AdventOfCode.Y2015.Day14.Star1.Reindeer

type Reindeer =
    private
        { Speed: int
          FlyTime: int
          RestTime: int }

let reindeer speed flyTime restTime =
    { Speed = speed
      FlyTime = flyTime
      RestTime = restTime }

let private sliceOff i size =
    if size > i then (i, 0) else (size, i - size)

let rec raceFor time reindeer =
    if time <= 0 then
        0
    else
        let (flyTime, time) = sliceOff time reindeer.FlyTime
        let (restTime, time) = sliceOff time reindeer.RestTime
        let distance = flyTime * reindeer.Speed
        distance + (reindeer |> raceFor time)

let findTopDistance reindeer time =
    reindeer |> Seq.map (raceFor time) |> Seq.max
