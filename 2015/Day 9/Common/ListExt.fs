[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day9.List

let permutations list =
    let rec inserts e =
        function
        | [] -> [ [ e ] ]
        | x :: xs as list ->
            (e :: list)
            :: (inserts e xs |> List.map (fun xs' -> x :: xs'))

    let addIntoEvery lists x = lists |> List.collect (inserts x)

    list |> List.fold addIntoEvery [ [] ]
