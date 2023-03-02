module AdventOfCode.Y2015.Day4.Hashing

open System
open System.Security.Cryptography
open System.Text

let hash (key: string) =
    let bytes = Encoding.ASCII.GetBytes key
    let hashed = MD5.HashData bytes
    Convert.ToHexString hashed