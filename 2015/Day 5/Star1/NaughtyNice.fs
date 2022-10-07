module AdventOfCode.Y2015.Day5.Star1.NaughtyNice

let private forbiddenStrings =
    Set.ofList [ "ab"; "cd"; "pq"; "xy" ]

let private vowels = Set.ofList [ "a"; "e"; "i"; "o"; "u" ]

let private contains (sub: string) (s: string) = s.Contains sub

let private containsForbiddenString s =
    forbiddenStrings
    |> Set.exists (fun forbidden -> s |> contains forbidden)

let private containsLetterTwiceInARow s =
    s |> Seq.pairwise |> Seq.exists (fun (a, b) -> a = b)

let private vowelCount s =
    vowels
    |> Set.filter (fun vowel -> s |> contains vowel)
    |> Set.count
    
let private contains3Vowels s =
    s |> vowelCount >= 3

let isNice s =
    s |> (not << containsForbiddenString)
    && s |> containsLetterTwiceInARow
    && s |> contains3Vowels
