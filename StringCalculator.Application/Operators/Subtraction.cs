using System;

namespace StringCalculator.Application.Operators
{
    public class Subtraction : Operator
    {
        public Subtraction(string calculation)
            : base(calculation)
        {
        }

        public override decimal GetResult()
        {
            return _valueA - _valueB;
        }
    }
}