namespace StringCalculator.Lib.DelimiterParsers

type SingleDelimiterParser() =
    interface IDelimiterParser with
        member _.Parse(delimiterPart: string) =
            [| delimiterPart |]