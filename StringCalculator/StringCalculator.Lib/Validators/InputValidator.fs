namespace StringCalculator.Lib.Validators

open StringCalculator.Lib.Exceptions

module InputValidator =

    let validateInput (numbers: string, delimiters: string[]) =
        let invalidSequences =
            delimiters
            |> Array.collect (fun d1 -> delimiters |> Array.map (fun d2 -> d1 + d2))

        if invalidSequences |> Array.exists numbers.Contains then
            raise (InvalidDelimiterSequenceException("Invalid input: consecutive delimiters are not allowed"))

    let validateDelimitersInInput (numbers: string, delimiters: string[]) =
        let inputDelimiters =
            numbers.ToCharArray()
            |> Array.fold
                (fun acc c ->
                    if not (System.Char.IsDigit c) && c <> '-' then
                        acc + string c
                    else
                        acc + " ")
                ""
            |> fun s -> s.Split([| ' ' |], System.StringSplitOptions.RemoveEmptyEntries)

        let invalidDelimiter =
            inputDelimiters |> Array.exists (fun d -> not (Array.contains d delimiters))

        if invalidDelimiter then
            raise (InvalidInputException("Invalid input: contains invalid delimiters"))
