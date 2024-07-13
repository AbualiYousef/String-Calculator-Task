namespace StringCalculator.Lib

open System
open StringCalculator.Lib.DelimiterFactory
open StringCalculator.Lib.NumberParser
open StringCalculator.Lib.Validators.NumberValidator
open StringCalculator.Lib.Validators.InputValidator

module StringCalculator =

    let add (input: string) : int =
        if String.IsNullOrWhiteSpace(input) then
            0
        else
            let delimiters, numbers = getDelimitersAndNumbers input
            validateInput (numbers, delimiters)
            validateDelimitersInInput (numbers, delimiters)
            let parsedNumbers = parseNumbers (numbers, delimiters)
            validateNegativeNumbers parsedNumbers
            let filteredNumbers = filterNumbers parsedNumbers
            filteredNumbers |> Array.sum
