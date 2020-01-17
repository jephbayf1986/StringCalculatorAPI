namespace StringCalculator.Application.Operators
{
    public class Addition : Operator
    {
        public Addition(string calculation)
            : base(calculation)
        {
        }

        public override decimal GetResult()
        {
            return _valueA + _valueB;
        }
    }
}
