module AdventOfCode.Y2015.Day15.Star1.Cookie

open AdventOfCode.Y2015.Day15

let private capacity ingredient = ingredient.Capacity

let private durability ingredient = ingredient.Durability

let private flavor ingredient = ingredient.Flavor

let private texture ingredient = ingredient.Texture

let scoreCookieMadeFrom (Recipe amountsByIngredient) =

    let amountsByIngredient = amountsByIngredient |> Map.toList

    let scoreRecipeBy selectProperty =
        amountsByIngredient
        |> List.map (fun (ingredient, (Teaspoons amount)) ->
            (ingredient |> selectProperty) * amount)
        |> List.sum
        |> (max 0)

    (scoreRecipeBy capacity)
    * (scoreRecipeBy durability)
    * (scoreRecipeBy flavor)
    * (scoreRecipeBy texture)

let rec private allConfigurations amount count =

    let configurationsStartingWith x =
        allConfigurations (amount - x) (count - 1)
        |> Seq.map (fun rest -> x :: rest)

    if count = 1 then
        Seq.singleton [ amount ]
    else
        Seq.init amount id |> Seq.collect configurationsStartingWith

let findOptimalScoreFor ingredients =

    let makeRecipeWith amounts =
        List.zip ingredients amounts |> makeRecipe

    allConfigurations 100 (ingredients |> List.length)
    |> Seq.map (List.map Teaspoons)
    |> Seq.map makeRecipeWith
    |> Seq.map scoreCookieMadeFrom
    |> Seq.max
