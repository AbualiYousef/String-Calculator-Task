namespace StringCalculator.Lib.DelimiterParsers

type MultipleDelimiterParser() =
    interface IDelimiterParser with
        member _.Parse(delimiterPart: string) =
            delimiterPart.Split([|'['; ']'|], System.StringSplitOptions.RemoveEmptyEntries)