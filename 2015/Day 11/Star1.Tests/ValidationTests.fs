module AdventOfCode.Y2015.Day11.Star1.ValidationTests

open Xunit
open Swensen.Unquote.Assertions
open AdventOfCode.Y2015.Day11.Star1.Validation

[<Theory>]
[<InlineData("qqrss")>]
[<InlineData("qqrsshahaha")>]
let ``Passwords must be 8 letters long`` password =
    validate password =! [ InvalidLength ]

[<Fact>]
let ``Passwords may not contain i`` () =
    let password = "qqrssabi"
    validate password =! [ InvalidLetter 'i' ]

[<Fact>]
let ``Passwords may not contain l`` () =
    let password = "qqrssabl"
    validate password =! [ InvalidLetter 'l' ]

[<Fact>]
let ``Passwords may not contain o`` () =
    let password = "qqrssabo"
    validate password =! [ InvalidLetter 'o' ]

[<Theory>]
[<InlineData("qrsqrsqr")>]
[<InlineData("qrsqrsqq")>]
[<InlineData("qrsqrqqq")>]
let ``Passwords contain at least two pairs of letters`` password =
    validate password =! [ InvalidPairCount ]

[<Fact>]
let ``Passwords contain straight of 3`` () =
    let password = "qrtaabbx"
    validate password =! [ NoStraight ]

[<Fact>]
let ``Valid passwords match all rules`` () =
    let password = "ghjaabcc"
    validate password =! []
