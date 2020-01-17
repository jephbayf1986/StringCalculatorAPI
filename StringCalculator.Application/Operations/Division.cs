using StringCalculator.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator.Application.Operations
{
    public class Division : IOperation
    {
        private int _quotent;
        private int _divisor;

        private readonly string symbol = OperationSymbol.Divide.ToString();

        public Division(string calculation)
        {
            
        }

        public decimal Perform()
        {
            return (decimal)_quotent / _divisor;
        }
    }
}