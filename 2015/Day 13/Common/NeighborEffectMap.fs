namespace AdventOfCode.Y2015.Day13

type NeighborEffectMap =
    private | NeighborEffectMap of Map<(PersonName * PersonName), HappinessUnit>

[<RequireQualifiedAccess>]
module NeighborEffectMap =

    let private empty = NeighborEffectMap Map.empty

    let add relation (NeighborEffectMap map) =
        map
        |> Map.add (relation.Person, relation.Neighbor) relation.Effect
        |> NeighborEffectMap

    let makeFrom relations =

        let addTo map relation = map |> add relation

        relations |> Seq.fold addTo empty

    let peopleIn (NeighborEffectMap map) =
        map |> Map.keys |> Seq.map fst |> Seq.distinct

    let happinessFor person neighbor (NeighborEffectMap map) =
        map |> Map.find (person, neighbor)
