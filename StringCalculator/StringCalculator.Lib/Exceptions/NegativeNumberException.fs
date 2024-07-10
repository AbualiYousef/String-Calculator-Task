namespace StringCalculator.Lib.Exceptions

type NegativeNumberException(message: string) =
    inherit System.Exception(message)
    override this.Message = message