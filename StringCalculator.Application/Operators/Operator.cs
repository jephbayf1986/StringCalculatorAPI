using StringCalculator.Application.StringHelpers;

namespace StringCalculator.Application.Operators
{
    public class Operator : IOperator
    {
        protected decimal _valueA;
        protected decimal _valueB;

        public Operator(string calculation)
        {
            OperationSplitter.Split(calculation, out _valueA, out _valueB);
        }

        public virtual decimal GetResult()
        {
            return 0;
        }
    }
}
