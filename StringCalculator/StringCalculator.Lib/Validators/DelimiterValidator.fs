namespace StringCalculator.Lib.Validators

open StringCalculator.Lib.Exceptions

module DelimiterValidator =

    let validateDelimiter (delimiterPart: string) =
        if
            (delimiterPart.StartsWith("[") && not (delimiterPart.EndsWith("]")))
            || delimiterPart.StartsWith("]")
        then
            raise (InvalidInputException("Invalid input: malformed custom delimiter"))
