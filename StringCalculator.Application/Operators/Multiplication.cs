namespace StringCalculator.Application.Operators
{
    public class Multiplication : Operator
    {
        public Multiplication(string calculation)
            : base(calculation)
        {
        }

        public override decimal GetResult()
        {
            return _valueA * _valueB;
        }
    }
}
