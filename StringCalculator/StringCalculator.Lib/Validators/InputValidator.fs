namespace StringCalculator.Lib.Validators

open StringCalculator.Lib.Exceptions

module InputValidator =
    let validateInput (input: string, delimiters: string[]) =
        let invalidSequences =
            delimiters
            |> Array.collect (fun d1 -> delimiters |> Array.map (fun d2 -> d1 + d2))

        if invalidSequences |> Array.exists input.Contains then
            raise (InvalidDelimiterSequenceException("Invalid input: consecutive delimiters are not allowed"))
