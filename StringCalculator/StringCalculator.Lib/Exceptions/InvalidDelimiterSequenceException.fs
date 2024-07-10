namespace StringCalculator.Lib.Exceptions

type InvalidDelimiterSequenceException(message: string) =
    inherit System.Exception(message)
    override this.Message = message
