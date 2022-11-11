[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day8.Star1.String

open System.Text.RegularExpressions

let private deleteRegex = Regex @"\"""
let private oneCharRegex = Regex @"(\\x[a-z0-9]{2})|(\\{2})|(\\\"")"

let private quoteEscapeChars = [| '\\'; '\"' |]
let private unicodeEscapeChars = [| '\\'; 'x' |]

let codeLength = String.length

let dataLength s =
    let shorter = oneCharRegex.Replace(s, "_")
    let shorter = deleteRegex.Replace(shorter, "")
    shorter.Length
