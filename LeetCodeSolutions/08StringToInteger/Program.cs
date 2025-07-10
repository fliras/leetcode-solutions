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
            int firstValidCharIndex = FindIndexOfFirstValidNumericChar(s);
            if (firstValidCharIndex == -1)
                return 0;

            string? validNumericString = ExtractValidNumericString(s, firstValidCharIndex);
            if (string.IsNullOrEmpty(validNumericString))
                return 0;

            return ParseStringToInteger(validNumericString);
        }

        static int FindIndexOfFirstValidNumericChar(string s)
        {
            int charIndex = 0;
            while (charIndex < s.Length)
            {
                char currentChar = s[charIndex];

                if (currentChar != ' ')
                {
                    if (!IsNumericSignal(currentChar) && !IsNumeric(currentChar))
                        return -1;

                    return charIndex;
                }

                charIndex++;
            }

            return -1;
        }

        static string? ExtractValidNumericString(string s, int charIndex)
        {
            string numericString = s[charIndex++].ToString();
            bool shouldContinue = true;

            while (shouldContinue && charIndex < s.Length)
            {
                char currentChar = s[charIndex++];
                if (IsALetter(currentChar) || IsNumericSignal(currentChar) || currentChar == ' ')
                    shouldContinue = false;
                else
                {
                    if (currentChar != '0')
                        numericString += currentChar.ToString();
                    else if (numericString.Length > 1 || (!IsNumericSignal(numericString[0]) && numericString[0] != '0'))
                        numericString += currentChar.ToString();
                }
            }

            return FormatNumericString(numericString);
        }

        static string? FormatNumericString(string numericString)
        {
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

        static bool IsALetter(char c)
        {
            return !IsNumeric(c) && !IsNumericSignal(c) && c != ' ';
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
