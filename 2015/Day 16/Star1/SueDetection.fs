module AdventOfCode.Y2015.Day16.Star1.SueDetection

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
    MFCSAM
    |> Map.forall (fun compound amount ->
        sue.Compounds |> Map.tryFind compound |> Option.forall ((=) amount))

let findSue sues = sues |> Seq.find matchesMFCSAM
