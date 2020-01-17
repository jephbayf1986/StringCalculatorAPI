using System;

namespace StringCalculator.Application.Operators
{
    public class Division : Operator
    {
        public Division(string calculation)
            : base (calculation)
        {
        }

        public override decimal GetResult()
        {
            if (_valueB == 0)
            {
                throw new DivideByZeroException();
            }

            decimal Result = _valueA / _valueB;

            return Math.Round(Result, 4);
        }
    }
}