namespace StringCalculator.Lib

module NumberParser =

    open System

    let parseNumbers (numbers: string, delimiters: string[]) : int[] =
        let splitNumbers = numbers.Split(delimiters, StringSplitOptions.None)

        splitNumbers
        |> Array.choose (fun n -> if n <> "" then Some(Int32.Parse(n)) else None)
        |> Array.filter (fun n -> n <= 1000)