module AdventOfCode.Y2015.Day11.Validation

type Error =
    | InvalidLetter of char
    | InvalidLength
    | InvalidPairCount
    | NoStraight

let private triplets s =
    s
    |> Seq.windowed 3
    |> Seq.map (fun v ->
        (v |> Array.item 0, v |> Array.item 1, v |> Array.item 2))

let private containsLetter (l: char) (password: Password) = password.Contains l

let private letterAt i (password: Password) = password |> Seq.item i

let private pairCountIn password =

    let length = password |> String.length

    let rec pairCountAfter i =
        if i > length - 2 then
            0
        else
            let c = password |> letterAt i
            let next = password |> letterAt (i + 1)

            if c = next then
                (pairCountAfter (i + 2)) + 1
            else
                pairCountAfter (i + 1)

    pairCountAfter 0

let private hasStraight (password: Password) =

    let isStraight (a, b, c) = b = a + 1 && c = b + 1

    password |> Seq.map (int) |> triplets |> Seq.exists isStraight

let private validateLength password =
    let length = password |> String.length

    [ if length <> 8 then
          yield InvalidLength ]

let private validateValidLetters password =
    [ if password |> containsLetter 'i' then
          yield InvalidLetter 'i'
      if password |> containsLetter 'o' then
          yield InvalidLetter 'o'
      if password |> containsLetter 'l' then
          yield InvalidLetter 'l' ]

let private validatePairs password =
    let pairCount = pairCountIn password

    [ if pairCount < 2 then
          yield InvalidPairCount ]

let private validateStraight password =
    [ if not <| hasStraight password then
          yield NoStraight ]

let private validators =
    [ validateLength; validateValidLetters; validatePairs; validateStraight ]

let validate password =

    let addValidation errors validator = errors @ (validator password)

    validators |> List.fold addValidation []

let isValid password = password |> validate |> List.isEmpty
