[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day10.Parse

open AdventOfCode

let private tryDigit c : Digit option =
    if c = '1' then Some 1
    elif c = '2' then Some 2
    elif c = '3' then Some 3
    elif c = '4' then Some 4
    elif c = '5' then Some 5
    elif c = '6' then Some 6
    elif c = '7' then Some 7
    elif c = '8' then Some 8
    elif c = '9' then Some 9
    else None

let private tryDigits s =
    s |> Seq.toList |> Option.traverseList tryDigit

let tryBlockSequence s =

    let rec parse blocks digits =
        match digits with
        | [] -> blocks
        | _ ->
            let digit = digits |> List.head
            let digitCount = digits |> List.length
            let nextBlockStart = digits |> List.tryFindIndex ((<>) digit)
            let count = nextBlockStart |> Option.defaultValue digitCount
            let block = { Digit = digit; Count = count }
            let rest = digits |> List.skip count
            parse (blocks @ [ block ]) rest

    s |> tryDigits |> Option.map (parse [])
