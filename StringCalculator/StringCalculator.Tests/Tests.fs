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
    
[<Theory>]
[<InlineData("//;\n1;2", 3)>]
[<InlineData("//$\n1$2", 3)>]
[<InlineData("//.\n1.2.3", 6)>]
[<InlineData("//\n\n1\n2\n3", 6)>]
let ``Add should support different delimiters`` (input: string, expected: int) =
    Add input |> should equal expected
    
[<Theory>]
[<InlineData("1,-2", "Negatives not allowed: -2")>]
[<InlineData("1,-2,-3", "Negatives not allowed: -2,-3")>]
let ``Add should throw exception for negative numbers`` (input: string, expectedMessage: string) =
    let ex = Assert.Throws<NegativeNumberException>(fun () -> Add input |> ignore)
    ex.Message |> should equal expectedMessage
    
[<Theory>]
[<InlineData("2,1001", 2)>]
[<InlineData("1000,1001,2", 1002)>]
[<InlineData("1000,0", 1000)>]
let ``Add should ignore numbers bigger than 1000`` (input: string, expected: int) =
    Add input |> should equal expected
    
[<Theory>]
[<InlineData("//[***]\n1***2***3", 6)>]
[<InlineData("//[abc]\n1abc2abc3", 6)>]
[<InlineData("//[$#:*]\n5$#:*6$#:*3", 14)>]

let ``Add should support delimiters of any length`` (input: string, expected: int) =
    Add input |> should equal expected