open System
open StringCalculator.Lib.StringCalculator
open StringCalculator.Lib.Exceptions

[<EntryPoint>]
let main argv =
    printfn "Enter a string of numbers to add (e.g., \"1,2,3\"): "
    let input = Console.ReadLine()

    try
        let result = add (input.Replace("\\n", "\n"))
        printfn $"The sum is: %d{result}"
    with
    | :? NegativeNumberException as ex -> printfn $"Error: %s{ex.Message}"
    | :? InvalidDelimiterSequenceException as ex -> printfn $"Error: %s{ex.Message}"
    | ex -> printfn $"Unhandled exception: %s{ex.Message}"

    0
