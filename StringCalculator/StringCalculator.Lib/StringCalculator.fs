namespace StringCalculator.Lib

open StringCalculator.Lib.DelimiterFactory
open StringCalculator.Lib.NumberParser
open StringCalculator.Lib.NumberValidator

module StringCalculator =

    let add (input: string) : int =
        if System.String.IsNullOrWhiteSpace(input) then
            0
        else
            let delimiters, numbers = getDelimitersAndNumbers input
            let parsedNumbers = parseNumbers (numbers, delimiters)
            validateNumbers parsedNumbers
            parsedNumbers |> Array.sum