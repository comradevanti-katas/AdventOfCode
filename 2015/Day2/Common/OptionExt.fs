[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day2.Option

let private (>>=) r f = Option.bind f r
let private rtn v = Some v

let traverseList f ls =
    let folder head tail =
        f head >>= (fun h -> tail >>= (fun t -> h :: t |> rtn))

    List.foldBack folder ls (rtn List.empty)

let sequenceList ls = traverseList id ls
