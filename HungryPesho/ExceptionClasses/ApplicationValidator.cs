namespace HungryPesho.ExceptionClasses
{
    public static class ApplicationValidator
    {
        public static void ValidateNumberValue(int value, int min = 0, int max = int.MaxValue, string name = "")
        {
            if (value < min || value > max)
            {
                throw new GameException("The value: " + name + " must be between " + min + " and " + max);
            }
        }

        public static void ValidateStringValue(string value, string name = "")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new GameException("The value: " + name + " can not be null or white space!");
            }
        }
    }
}