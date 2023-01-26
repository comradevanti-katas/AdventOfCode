module AdventOfCode.Y2015.Day13.SeatingArrangement

let rec allArrangements list =

    let arrangementsStartingAt index =
        let item = list |> List.item index

        list
        |> List.removeAt index
        |> allArrangements
        |> Seq.map (fun rest -> item :: rest)

    match list with
    | [] -> Seq.singleton []
    | _ ->
        seq { 0 .. (list |> List.length) - 1 }
        |> Seq.collect arrangementsStartingAt

let rec itemRepeated i list =
    let length = list |> List.length

    if i < 0 then list |> itemRepeated (i + length)
    elif i >= length then list |> itemRepeated (i - length)
    else list |> List.item i

let calcMaximumHappinessFor map =

    let rec happinessFor arrangement =

        let happinessForPersonAt index =

            let person = arrangement |> List.item index
            let prev = arrangement |> itemRepeated (index - 1)
            let next = arrangement |> itemRepeated (index + 1)

            (map |> NeighborEffectMap.happinessFor person prev)
            + (map |> NeighborEffectMap.happinessFor person next)

        [ 0 .. (arrangement |> List.length) - 1 ]
        |> List.sumBy happinessForPersonAt

    let people = NeighborEffectMap.peopleIn map |> Seq.toList
    let arrangements = people |> allArrangements

    arrangements |> Seq.map happinessFor |> Seq.max
