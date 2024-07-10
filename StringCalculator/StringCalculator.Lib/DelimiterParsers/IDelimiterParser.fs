namespace StringCalculator.Lib.DelimiterParsers


type IDelimiterParser =
    abstract member Parse: string -> string[]