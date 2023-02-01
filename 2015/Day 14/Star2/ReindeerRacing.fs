module AdventOfCode.Y2015.Day14.Star2.ReindeerRacing

open AdventOfCode.Y2015.Day14.Reindeer

let private allMaxBy f seq =
    seq |> Seq.groupBy f |> Seq.maxBy fst |> snd

let private addPoint pointsByName name =
    pointsByName |> Map.change name (Option.map (fun points -> points + 1))

let private leaderNames distancesByName =
    distancesByName |> Map.toSeq |> allMaxBy snd |> Seq.map fst

let isFlyingAt second reindeer =
    let timeInBurst = second % (burstTimeOf reindeer)
    timeInBurst < flyTimeOf reindeer

let raceForPoints time reindeer =

    let reindeerByName =
        reindeer
        |> Seq.map (fun reindeer -> (nameOf reindeer, reindeer))
        |> Map.ofSeq

    let progress second distancesByName =
        distancesByName
        |> Map.map (fun name distance ->
            let reindeer = reindeerByName |> Map.find name

            if reindeer |> isFlyingAt second then
                distance + (speedOf reindeer)
            else
                distance)

    let rec race second distancesByName pointsByName =
        if second = time then
            pointsByName
        else
            let distancesByName = distancesByName |> progress second
            let leaderNames = leaderNames distancesByName
            let pointsByName = (pointsByName, leaderNames) ||> Seq.fold addPoint
            race (second + 1) distancesByName pointsByName

    let initialDistancesByName = reindeerByName |> Map.map (fun _ _ -> 0)
    let initialPointsByName = reindeerByName |> Map.map (fun _ _ -> 0)

    race 0 initialDistancesByName initialPointsByName

let winnerPoints reindeer time =
    reindeer |> raceForPoints time |> Map.toSeq |> Seq.maxBy snd |> snd
