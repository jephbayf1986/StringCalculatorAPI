namespace StringCalculator.Application.Constants
{
    public static class RegexPattern
    {
        public const string AnyPositive = "(\\d+\\.\\d+|\\d+)";

        public const string AnyValue = "(-\\d+\\.\\d+|\\d+\\.\\d+|-\\d+|\\d+)";
    }
}