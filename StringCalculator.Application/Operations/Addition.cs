using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.Operations
{
    public class Addition : IOperation
    {
        private int _valueA;
        private int _valueB;

        private readonly string symbol = OperationSymbol.Add.ToString();

        public Addition(string calculation)
        {

        }

        public decimal Perform()
        {
            return _valueA + _valueB;
        }
    }
}
