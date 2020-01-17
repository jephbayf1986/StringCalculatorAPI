namespace StringCalculator.Application.StringHelpers
{
    public interface IStringModifier
    {
        void SubstituteOperationsWithResult(ref string calculationString, string symbol);
    }
}