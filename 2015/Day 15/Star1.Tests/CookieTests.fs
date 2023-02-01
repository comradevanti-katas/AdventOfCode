module AdventOfCode.Y2015.Day15.Star1.CookieTests

open AdventOfCode.Y2015.Day15
open AdventOfCode.Y2015.Day15.Star1.Cookie
open Swensen.Unquote.Assertions
open Xunit

[<Fact>]
let ``Score of cookie is calculated correctly`` () =

    let butterscotch =
        { Capacity = -1
          Durability = -2
          Flavor = 6
          Texture = 3 }

    let cinnamon =
        { Capacity = 2
          Durability = 3
          Flavor = -2
          Texture = -1 }

    let recipe =
        makeRecipe
            [ 44 |> teaspoonsOf butterscotch; 56 |> teaspoonsOf cinnamon ]

    scoreCookieMadeFrom recipe =! 62842880

[<Fact>]
let ``Can find the optimal score`` () =
    let butterscotch =
        { Capacity = -1
          Durability = -2
          Flavor = 6
          Texture = 3 }

    let cinnamon =
        { Capacity = 2
          Durability = 3
          Flavor = -2
          Texture = -1 }

    let ingredients = [ butterscotch; cinnamon ]
    findOptimalScoreFor ingredients =! 62842880
