namespace StringCalculator.Application.StringHelpers
{
    public interface IOperationIdentifier
    {
        string GetNextOperationMatch(string completeString, string symbol);
    }
}