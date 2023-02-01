[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day15.Parse

open FSharp.Text.RegexProvider
open FSharp.Text.RegexExtensions

type IngredientRegex =
    Regex< @"^[^\-\d]+(?<capacity>[\-\d]+)[^\-\d]*(?<durability>[\-\d]+)[^\-\d]+(?<flavor>[\-\d]+)[^\-\d]+(?<texture>[\-\d]+)[^\-\d]+[\-\d]+$" >

let ingredientRegex = IngredientRegex()

let toIngredient s =
    ingredientRegex.TryTypedMatch s
    |> Option.map (fun m ->
        { Capacity = m.capacity.AsInt
          Durability = m.durability.AsInt
          Flavor = m.flavor.AsInt
          Texture = m.texture.AsInt })
