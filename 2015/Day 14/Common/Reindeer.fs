module AdventOfCode.Y2015.Day14.Reindeer

type Reindeer =
    private
        { Name: string
          Speed: int
          FlyTime: int
          RestTime: int }

let reindeer name speed flyTime restTime =
    { Name = name
      Speed = speed
      FlyTime = flyTime
      RestTime = restTime }

let nameOf reindeer = reindeer.Name

let speedOf reindeer = reindeer.Speed

let flyTimeOf reindeer = reindeer.FlyTime

let restTimeOf reindeer = reindeer.RestTime

let burstTimeOf reindeer = reindeer.FlyTime + reindeer.RestTime
