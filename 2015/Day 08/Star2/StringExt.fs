[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode.Y2015.Day8.Star2.String


let encode (s: string) =
    "\""
    + s.Replace("\\", "\\\\").Replace("\"", "\\\"")
    + "\""
