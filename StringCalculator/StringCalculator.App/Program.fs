module Program

open System

let Add (numbers: string) : int =
    if String.IsNullOrWhiteSpace(numbers) then
        0
    else
        let splitNumbers = numbers.Split([|','|])
        match splitNumbers.Length with
        | 1 -> Int32.Parse(splitNumbers[0])
        | 2 -> (Int32.Parse(splitNumbers[0]) + Int32.Parse(splitNumbers[1]))
        | _ -> failwith "Invalid input"