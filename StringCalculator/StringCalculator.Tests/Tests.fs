module Tests

open Xunit
open FsUnit.Xunit
open Program

[<Theory>]
[<InlineData("", 0)>]
[<InlineData("1", 1)>]
[<InlineData("1,2", 3)>]
[<InlineData("5,6", 11)>]

let ``Add should handle 0, 1, or 2 numbers`` (input: string, expected: int) =
    Add input |> should equal expected
    
[<Theory>]
[<InlineData("1,2,3", 6)>]
[<InlineData("1,2,3,4", 10)>]
let ``Add should handle unknown amount of numbers`` (input: string, expected: int) =
    Add input |> should equal expected
    
[<Theory>]
[<InlineData("1\n2,3", 6)>]
[<InlineData("1\n2\n3", 6)>]
[<InlineData("1,2\n3,4", 10)>]
let ``Add should handle new lines between numbers`` (input: string, expected: int) =
    Add input |> should equal expected