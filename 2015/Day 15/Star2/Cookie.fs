module AdventOfCode.Y2015.Day15.Star2.Cookie

open AdventOfCode.Y2015.Day15
open AdventOfCode.Y2015.Day15.Cookie

let rec private allConfigurations amount count =

    let configurationsStartingWith x =
        allConfigurations (amount - x) (count - 1)
        |> Seq.map (fun rest -> x :: rest)

    if count = 1 then
        Seq.singleton [ amount ]
    else
        Seq.init amount id |> Seq.collect configurationsStartingWith

let private totalCaloriesOf (Recipe recipe) =
    recipe
    |> Map.toSeq
    |> Seq.sumBy (fun (ingredient, Teaspoons amount) ->
        ingredient.Calories * amount)

let findOptimalScoreFor ingredients =
    let makeRecipeWith amounts =
        List.zip ingredients amounts |> makeRecipe

    allConfigurations 100 (ingredients |> List.length)
    |> Seq.map (List.map Teaspoons)
    |> Seq.map makeRecipeWith
    |> Seq.filter (fun recipe -> totalCaloriesOf recipe = 500)
    |> Seq.map scoreCookieMadeFrom
    |> Seq.max
