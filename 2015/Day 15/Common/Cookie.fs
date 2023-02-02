module AdventOfCode.Y2015.Day15.Cookie

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
