namespace StringCalculator.Application.Operators
{
    public interface IOperatorFactory
    {
        IOperator Create(string operationString);
    }
}