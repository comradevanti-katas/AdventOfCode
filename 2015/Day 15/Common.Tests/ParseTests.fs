module AdventOfCode.Y2015.Day15.ParseTests

open Xunit
open AdventOfCode.Y2015.Day15
open Swensen.Unquote.Assertions

[<Fact>]
let ``Can parse valid ingredient`` () =
    let s =
        "Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8"

    let expected =
        { Capacity = -1
          Durability = -2
          Flavor = 6
          Texture = 3
          Calories = 8 }

    Parse.toIngredient s =! Some expected
