module AdventOfCode.Y2015.Day18.DomainTests

open Xunit
open Swensen.Unquote.Assertions

[<Fact>]
let ``Toggling a on light turns it off`` () = onLight |> toggle =! offLight

[<Fact>]
let ``Toggling a off light turns it on`` () = offLight |> toggle =! onLight

[<Theory>]
[<InlineData(0, 0, 1)>]
[<InlineData(1, 1, 6)>]
[<InlineData(2, 2, 4)>]
[<InlineData(3, 3, 1)>]
let ``Correct on neighbor count is found`` x y expected =
    let grid =
        gridOf
            [ [ onLight; offLight; onLight; offLight ]
              [ onLight; offLight; onLight; offLight ]
              [ onLight; onLight; offLight; offLight ]
              [ offLight; offLight; onLight; onLight ] ]

    grid |> onNeighborCountAt (x, y) =! expected
