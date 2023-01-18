module AdventOfCode.Y2015.Day12.Star2.JSONValidation

open Newtonsoft.Json.Linq

let private isArray (jToken: JToken) = jToken.Type = JTokenType.Array

let private isInt (jToken: JToken) = jToken.Type = JTokenType.Integer

let private isObject (jToken: JToken) = jToken.Type = JTokenType.Object

let private hasRed (jObject: JObject) =

    let isRed (token: JToken) =
        token.Type = JTokenType.String && token.Value<string>() = "red"

    jObject.PropertyValues() |> Seq.exists isRed

let sumIn json =

    let rec sumInToken (jToken: JToken) =

        let sumInObject (jObject: JObject) =
            if jObject |> hasRed then
                0
            else
                jObject.PropertyValues() |> Seq.sumBy sumInToken

        let sumInArray (jArray: JArray) =
            jArray.Values() |> Seq.sumBy sumInToken

        if jToken |> isArray then
            jToken :?> JArray |> sumInArray
        else if jToken |> isInt then
            jToken.Value<int>()
        elif jToken |> isObject then
            jToken :?> JObject |> sumInObject
        else
            0

    json |> JToken.Parse |> sumInToken
