using StringCalculator.Application.Constants;

namespace StringCalculator.Application.StringHelpers
{
    public interface IStringModifier
    {
        void SubstituteOperationsWithResult(ref string calculationString, OperationSymbol symbol);
    }
}