namespace StringCalculator.Lib

module NumberParser =

    open System

    let parseNumbers (numbers: string, delimiters: string[]) : int[] =
        let splitNumbers = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        splitNumbers |> Array.map Int32.Parse
