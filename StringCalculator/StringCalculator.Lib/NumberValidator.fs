namespace StringCalculator.Lib

open StringCalculator.Lib.Exceptions

module NumberValidator =

    let validateNumbers (numbers: int[]) =
        let negatives = numbers |> Array.filter (fun n -> n < 0)
        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ","
            raise (NegativeNumberException $"Negatives not allowed: %s{message}")