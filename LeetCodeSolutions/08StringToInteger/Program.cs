namespace _08StringToInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"teu pai aquele corno: {MyAtoi(Console.ReadLine())}");
            Console.ReadKey();
        }

        static int MyAtoi(string s)
        {
            string? numericString = ExtractValidNumericString(s);
            if (numericString == null)
                return 0;

            return ParseStringToInteger(numericString);
        }

        static string? ExtractValidNumericString(string s)
        {
            string substringValue = string.Empty;

            int i = 0;
            bool shouldContinue = true;

            while (shouldContinue && i < s.Length)
            {
                char currentChar = s[i++];

                if (currentChar == ' ')
                {
                    if (!substringValue.Equals(string.Empty))
                        shouldContinue = false;
                }
                else if (IsNumericSignal(currentChar))
                {
                    if (!substringValue.Equals(string.Empty))
                        shouldContinue = false;
                    else
                        substringValue = currentChar.ToString();
                }
                else if (IsNumeric(currentChar))
                {
                    if (currentChar != '0')
                        substringValue += currentChar.ToString();
                    else if (substringValue.Equals(string.Empty))
                        substringValue += currentChar.ToString();
                    else if (substringValue.Length > 1 || (!IsNumericSignal(substringValue[0]) && substringValue[0] != '0'))
                        substringValue += currentChar.ToString();
                }
                else
                {
                    shouldContinue = false;
                }
            }

            return AdjustExtractedNumericString(substringValue);
        }

        static string? AdjustExtractedNumericString(string numericString)
        {
            if (numericString.Equals(string.Empty))
                return null;

            bool substringHasOnlyNumericSignal = numericString.Length == 1 && IsNumericSignal(numericString[0]);
            if (substringHasOnlyNumericSignal)
                return null;

            bool numberIsExplicitlyPositive = numericString[0] == '+';
            if (numberIsExplicitlyPositive)
                return numericString[1..];

            return numericString;
        }

        static int ParseStringToInteger(string s)
        {
            if (NumericStringOutOfIntSuperiorLimit(s))
                return Int32.MaxValue;
            
            if (NumericStringOutOfIntInferiorLimit(s))
                return Int32.MinValue;

            return int.Parse(s);
        }

        static bool NumericStringOutOfIntSuperiorLimit(string s)
        {
            string maxIntStr = Int32.MaxValue.ToString();
            bool valueIsPositive = s[0] != '-';
            return valueIsPositive && (s.Length > maxIntStr.Length || (s.Length == maxIntStr.Length && String.Compare(s, maxIntStr) > 0));
        }

        static bool NumericStringOutOfIntInferiorLimit(string s)
        {
            string minIntStr = Int32.MinValue.ToString();
            bool valueIsNegative = s[0] == '-';
            return valueIsNegative && (s.Length > minIntStr.Length || (s.Length == minIntStr.Length && String.Compare(s, minIntStr) > 0));
        }

        static bool IsNumeric(char c)
        {
            return c >= 48 && c <= 57;
        }

        static bool IsNumericSignal(char c)
        {
            return c == '-' || c == '+';
        }
    }
}
