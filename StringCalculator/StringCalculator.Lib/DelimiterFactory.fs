namespace StringCalculator.Lib

open StringCalculator.Lib.DelimiterParsers

module DelimiterFactory =

    let createDelimiterParser (delimiterPart: string) : IDelimiterParser =
        if delimiterPart.Contains("][") || (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]")) then
            MultipleDelimiterParser() :> IDelimiterParser
        else
            SingleDelimiterParser() :> IDelimiterParser

    let getDelimitersAndNumbers (input: string) : string[] * string =
        if input.StartsWith("//") then
            if input[2] = '\n' then
                ([| "\n" |], input.Substring(4))
            else
                let endIndex = input.IndexOf('\n')
                let delimiterPart = input.Substring(2, endIndex - 2)
                let parser = createDelimiterParser delimiterPart
                let delimiters = parser.Parse(delimiterPart)
                (delimiters, input.Substring(endIndex + 1))
        else
            ([| ","; "\n" |], input)