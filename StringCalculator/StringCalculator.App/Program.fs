module Program

open System

type NegativeNumberException(message: string) =
    inherit Exception(message)
    override this.Message = message

let Add (numbers: string) : int =
    if String.IsNullOrWhiteSpace(numbers) then
        0
    else
        let delimiters, numbers =
            if numbers.StartsWith("//") then
                if numbers[2] = '\n' then
                    ([| "\n" |], numbers.Substring(4))
                else
                    let endIndex = numbers.IndexOf('\n')
                    let delimiterPart = numbers.Substring(2, endIndex - 2)

                    let delimiters =
                        if delimiterPart.StartsWith("[") then
                            delimiterPart.Split([| '['; ']' |], StringSplitOptions.RemoveEmptyEntries)
                        else
                            [| delimiterPart |]

                    (delimiters, numbers.Substring(endIndex + 1))
            else
                ([| ","; "\n" |], numbers)

        let splitNumbers = numbers.Split(delimiters, StringSplitOptions.None)

        let parsedNumbers =
            splitNumbers |> Array.map Int32.Parse |> Array.filter (fun n -> n <= 1000)

        let negatives = parsedNumbers |> Array.filter (fun n -> n < 0)

        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ","
            raise (NegativeNumberException $"Negatives not allowed: %s{message}")

        parsedNumbers |> Array.sum
