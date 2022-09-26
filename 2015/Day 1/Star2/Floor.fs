module AdventOfCode.Y2015.Day1.Star2.Floor

open AdventOfCode.Y2015.Day1.Star1

let findBasementIndexFor directions =
    
    let rec findBasement floor i =
        let direction = directions |> List.item i
        let newFloor = Floor.moveFrom floor direction
        if newFloor = -1 then i + 1
        else findBasement newFloor (i + 1)
        
    findBasement 0 0