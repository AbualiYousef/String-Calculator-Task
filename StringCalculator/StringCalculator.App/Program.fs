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
    | :? InvalidInputException as ex -> printfn $"Error: %s{ex.Message}"
    | ex -> printfn $"Unhandled exception: %s{ex.Message}"

    0

// Functional Programming Solution
// namespace StringCalculator.App
//
// open System
//
// module Program =
//
//     type NegativeNumberException(message: string) =
//         inherit Exception(message)
//         override this.Message = message
//
//     type InvalidInputException(message: string) =
//         inherit Exception(message)
//         override this.Message = message
//
//     let private parseMultipleDelimiters (delimiterPart: string) : string[] =
//         delimiterPart.Split([| '['; ']' |], StringSplitOptions.RemoveEmptyEntries)
//
//     let private parseSingleDelimiter (delimiterPart: string) : string[] = [| delimiterPart |]
//
//     let private createDelimiterParser (delimiterPart: string) : string -> string[] =
//         if delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]") then
//             parseMultipleDelimiters
//         else
//             parseSingleDelimiter
//
//     let private extractDelimitersAndNumbers (input: string) : string[] * string =
//         if input.StartsWith("//") then
//             if input.Length < 4 then
//                 raise (InvalidInputException("Invalid input: malformed custom delimiter"))
//
//             if input[2] = '\n' then
//                 ([| "\n" |], input.Substring(4))
//             else
//                 let endIndex = input.IndexOf('\n')
//
//                 if endIndex = -1 then
//                     raise (InvalidInputException("Invalid input: malformed custom delimiter"))
//
//                 let delimiterPart = input.Substring(2, endIndex - 2)
//                 let parser = createDelimiterParser delimiterPart
//                 let delimiters = parser delimiterPart
//                 let numbers = input.Substring(endIndex + 1)
//                 (delimiters, numbers)
//         else
//             let defaultDelimiters = [| ","; "\n" |]
//             (defaultDelimiters, input)
//
//     let parseNumbers (numbers: string, delimiters: string[]) : int[] =
//         let splitNumbers = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
//         splitNumbers |> Array.map Int32.Parse
//
//     let validateNegativeNumbers (numbers: int[]) : int[] =
//         let negatives = numbers |> Array.filter (fun n -> n < 0)
//
//         if negatives.Length > 0 then
//             let message = negatives |> Array.map string |> String.concat ","
//             raise (NegativeNumberException $"Negatives not allowed: %s{message}")
//
//         numbers
//
//     let filterNumbers (numbers: int[]) : int[] =
//         numbers |> Array.filter (fun n -> n <= 1000)
//
//     let add (input: string) : int =
//         if String.IsNullOrWhiteSpace(input) then
//             0
//         else
//             input
//             |> extractDelimitersAndNumbers
//             |> fun (delimiters, numbers) -> parseNumbers (numbers, delimiters)
//             |> validateNegativeNumbers
//             |> filterNumbers
//             |> Array.sum
//
//     [<EntryPoint>]
//     let main argv =
//         printfn "Enter a string of numbers to add (e.g., \"1,2,3\"):"
//         let input = Console.ReadLine()
//
//         try
//             let result = add (input.Replace("\\n", "\n"))
//             printfn $"The sum is: %d{result}"
//         with
//         | :? NegativeNumberException as ex -> printfn $"Error: %s{ex.Message}"
//         | :? InvalidInputException as ex -> printfn $"Error: %s{ex.Message}"
//         | ex -> printfn $"Unhandled exception: %s{ex.Message}"
//
//         0
