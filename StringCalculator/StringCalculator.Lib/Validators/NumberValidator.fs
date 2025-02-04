﻿namespace StringCalculator.Lib.Validators

open StringCalculator.Lib.Exceptions

module NumberValidator =

    let validateNegativeNumbers (numbers: int[]) =
        let negatives = numbers |> Array.filter (fun n -> n < 0)

        if negatives.Length > 0 then
            let message = negatives |> Array.map string |> String.concat ","
            raise (NegativeNumberException $"Negatives not allowed: %s{message}")

    let filterNumbers (numbers: int[]) : int[] =
        numbers |> Array.filter (fun n -> n <= 1000)
