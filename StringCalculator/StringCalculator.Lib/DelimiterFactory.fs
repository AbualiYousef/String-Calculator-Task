namespace StringCalculator.Lib

open StringCalculator.Lib.DelimiterParsers
open StringCalculator.Lib.Exceptions
open StringCalculator.Lib.Validators.DelimiterValidator


module DelimiterFactory =

    let private createDelimiterParser (delimiterPart: string) : IDelimiterParser =
        if
            delimiterPart.Contains("][")
            || (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
        then
            MultipleDelimiterParser() :> IDelimiterParser
        else
            SingleDelimiterParser() :> IDelimiterParser

    let getDelimitersAndNumbers (input: string) : string[] * string =
        if input.StartsWith("//") then
            if input.Length < 4 then
                raise (InvalidInputException("Invalid input: malformed custom delimiter"))

            if input[2] = '\n' then
                ([| "\n" |], input.Substring(4))
            else
                let endIndex = input.IndexOf('\n')

                if endIndex = -1 then
                    raise (InvalidInputException("Invalid input: malformed custom delimiter"))

                let delimiterPart = input.Substring(2, endIndex - 2)
                validateDelimiter delimiterPart
                let parser = createDelimiterParser delimiterPart
                let delimiters = parser.Parse(delimiterPart)
                (delimiters, input.Substring(endIndex + 1))
        else
            ([| ","; "\n" |], input)
