namespace StringCalculator.Lib.Exceptions

open System

type InvalidInputException(message: string) =
    inherit Exception(message)
    override this.Message = message
