using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.Operations
{
    public class Multiply : IOperation
    {
        private int _multiplier;
        private int _multiplicand;

        private readonly string symbol = OperationSymbol.Multiply.ToString();

        public Multiply(string calculation)
        {

        }

        public decimal Perform()
        {
            return _multiplier * _multiplicand;
        }
    }
}
