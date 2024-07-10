module Program

open System
       
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
                    let delimiter = numbers.Substring(2, endIndex - 2)
                    ([| delimiter |], numbers.Substring(endIndex + 1))
            else
                ([| ","; "\n" |], numbers)

        let splitNumbers = numbers.Split(delimiters, StringSplitOptions.None)
        splitNumbers |> Array.map Int32.Parse |> Array.sum