using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Application.Operators
{
    public class OperatorFactory : IOperatorFactory
    {
        private Dictionary<string, Func<string, IOperator>> operationDictionary => new Dictionary<string, Func<string, IOperator>>()
            {
                { OperatorSymbol.Add, _createAddition },
                { OperatorSymbol.Subtract, _createSubtraction },
                { OperatorSymbol.Multiply, _createMultiplication },
                { OperatorSymbol.Divide, _createDivision }
            };

        public IOperator Create(string operationString)
        {
            KeyValuePair<string, Func<string, IOperator>> operationToCreate = operationDictionary.FirstOrDefault(d => operationString.Contains(d.Key));

            if (operationToCreate.Value == null)
            {
                throw new ArgumentException("The Input Parameter does not contain a valid operator");
            }

            return operationToCreate.Value(operationString);
        }

        private IOperator _createAddition(string operationString)
        {
            return new Addition(operationString);
        }

        private IOperator _createSubtraction(string operationString)
        {
            return new Subtraction(operationString);
        }

        private IOperator _createMultiplication(string operationString)
        {
            return new Multiplication(operationString);
        }

        private IOperator _createDivision(string operationString)
        {
            return new Division(operationString);
        }
    }
}