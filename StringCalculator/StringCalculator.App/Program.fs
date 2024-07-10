module Program

open System

let Add (numbers: string) : int =
    if String.IsNullOrWhiteSpace(numbers) then
        0
    else
        let splitNumbers = numbers.Split([| ',' |])
        splitNumbers |> Array.map Int32.Parse |> Array.sum