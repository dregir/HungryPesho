namespace HungryPesho.ExceptionClasses
{
    using System;

    public static class ApplicationValidator
    {
        public static void ValidateNumberValue(int value, int min = 0, int max = int.MaxValue)
        {
            if (value < min || value > max)
            {
                throw new GameException("The value: " + value.GetType().Name + " mist be between " + min + " and " + max);
            }
        }

        public static void ValidateStringValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new GameException("The value: " + value.GetType().Name + " cannot be null or white space!");
            }
        }
    }
}