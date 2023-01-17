module AdventOfCode.Y2015.Day11.PasswordGenTest

open Xunit
open AdventOfCode.Y2015.Day11.PasswordGen
open Swensen.Unquote.Assertions

[<Theory>]
[<InlineData("xx", "xy")>]
[<InlineData("xy", "xz")>]
[<InlineData("xz", "ya")>]
[<InlineData("ya", "yb")>]
let ``Passwords are incremented correctly`` password expected =
    increment password =! expected

[<Fact>]
let ``Passwords are incremented until a valid one is found`` () =
    let validated = "ghijklmn" |> findNextPassword
    validated =! "ghjaabcc"
