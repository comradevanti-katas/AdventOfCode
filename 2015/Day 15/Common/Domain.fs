[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode.Y2015.Day15.Domain

type Ingredient =
    { Capacity: int
      Durability: int
      Flavor: int
      Texture: int }

type Amount = Teaspoons of int

type Recipe = Recipe of Map<Ingredient, Amount>

let makeRecipe ingredientsAndAmounts =
    ingredientsAndAmounts |> Map.ofSeq |> Recipe

let teaspoonsOf ingredient teaspoons = (ingredient, Teaspoons teaspoons)
