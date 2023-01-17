module AdventOfCode.Y2015.Day10.ParseTests

open Xunit

type TestCase =
    { String: string; Expected: Block list }

let cases =
    [ [| { String = ""; Expected = [] } |]
      [| { String = "1"
           Expected = [ { Digit = 1; Count = 1 } ] } |]
      [| { String = "11"
           Expected = [ { Digit = 1; Count = 2 } ] } |]
      [| { String = "21"
           Expected = [ { Digit = 2; Count = 1 }; { Digit = 1; Count = 1 } ] } |]
      [| { String = "1211"
           Expected =
             [ { Digit = 1; Count = 1 }
               { Digit = 2; Count = 1 }
               { Digit = 1; Count = 2 } ] } |]
      [| { String = "1113122113"
           Expected =
             [ { Digit = 1; Count = 3 }
               { Digit = 3; Count = 1 }
               { Digit = 1; Count = 1 }
               { Digit = 2; Count = 2 }
               { Digit = 1; Count = 2 }
               { Digit = 3; Count = 1 } ] } |] ]

[<Theory>]
[<MemberData(nameof (cases))>]
let ``Valid entries are parsed correctly`` case =
    let parsed = Parse.tryBlockSequence case.String
    Assert.Equal(Some case.Expected, parsed)
