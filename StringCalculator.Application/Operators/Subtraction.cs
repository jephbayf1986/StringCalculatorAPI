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
            if (_valueB > _valueA)
            {
                throw new ArgumentOutOfRangeException("Cannot process negative results");
            }

            return _valueA - _valueB;
        }
    }
}