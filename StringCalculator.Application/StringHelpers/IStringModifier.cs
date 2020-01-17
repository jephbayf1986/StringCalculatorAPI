using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.StringHelpers
{
    public interface IStringModifier
    {
        void SubstituteOperationsWithResult(ref string calculationString, OperationSymbol symbol);
    }
}