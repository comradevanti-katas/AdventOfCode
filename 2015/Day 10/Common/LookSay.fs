module AdventOfCode.Y2015.Day10.LookSay

open AdventOfCode.Y2015.Day10

let private merge blocks =

    let merge2 b1 b2 =
        if b1.Digit = b2.Digit then
            let totalCount = b1.Count + b2.Count

            [ { Digit = b1.Digit; Count = totalCount } ]
        else
            [ b1; b2 ]

    let mergeInto merged block =
        match merged with
        | [] -> [ block ]
        | head :: rest -> (merge2 block head) @ rest

    blocks |> Seq.fold mergeInto [] |> List.rev

let lookSay blocks =
    blocks
    |> List.collect (fun block ->
        [ { Digit = block.Count; Count = 1 }
          { Digit = block.Digit; Count = 1 } ])
    |> merge

let rec lookSayTimes remaining blocks =
    if remaining = 0 then
        blocks
    else
        blocks |> lookSay |> lookSayTimes (remaining - 1)
