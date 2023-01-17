module AdventOfCode.Y2015.Day11.Star1.PasswordGen

open AdventOfCode.Y2015.Day11.Star1.Validation

let private mapAt i f arr =
    arr |> Array.mapi (fun i' item -> if i = i' then f item else item)

let private incChar (c: char) =
    if c = 'z' then 'a' else c |> int |> (+) 1 |> char

let increment (password: Password) =
    let rec incrementAt i chars =
        if i < 0 then
            chars
        else
            let incremented = chars |> mapAt i incChar

            if incremented |> Array.item i = 'a' then
                incremented |> incrementAt (i - 1)
            else
                incremented

    let lastIndex = (password |> Seq.length) - 1
    let newChars = password |> Seq.toArray |> incrementAt lastIndex
    new string (newChars)

let rec findNextPassword password =
    if password |> isValid then
        password
    else
        password |> increment |> findNextPassword
