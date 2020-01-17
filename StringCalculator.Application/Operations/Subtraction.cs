using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.Operations
{
    public class Subtraction : IOperation
    {
        private int _minuend;
        private int _subtrahend;

        private readonly string symbol = OperationSymbol.Subtract.ToString();

        public Subtraction(string calculation)
        {

        }

        public decimal Perform()
        {
            return _minuend - _subtrahend;
        }
    }
}