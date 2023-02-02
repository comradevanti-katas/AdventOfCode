module AdventOfCode.Y2015.Day16.Star2.SueDetection

open AdventOfCode.Y2015.Day16

let private MFCSAM: CompoundTable =
    Map.ofSeq
        [ "children", 3
          "cats", 7
          "samoyeds", 2
          "pomeranians", 3
          "akitas", 0
          "vizslas", 0
          "goldfish", 5
          "trees", 3
          "cars", 2
          "perfumes", 1 ]

let private matchesMFCSAM sue =

    let hasCorrectAmountOf compound amount foundAmount =
        if compound = "cats" || compound = "trees" then
            foundAmount > amount
        elif compound = "pomeranians" || compound = "goldfish" then
            foundAmount < amount
        else
            foundAmount = amount

    MFCSAM
    |> Map.forall (fun compound amount ->
        sue.Compounds
        |> Map.tryFind compound
        |> Option.forall (hasCorrectAmountOf compound amount))

let findSue sues = sues |> Seq.find matchesMFCSAM
