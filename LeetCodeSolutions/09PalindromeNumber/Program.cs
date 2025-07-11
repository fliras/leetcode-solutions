namespace _09PalindromeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"{number} is a palindrome: {IsPalindrome(number)}");
            Console.ReadKey();
        }

        static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            int copyOfx = x;
            int numberOfDigits = (int)Math.Log10(copyOfx) + 1;
            int xAddedReversely = 0;

            for (int i = numberOfDigits; i >= 1; i--)
            {
                int currentDigit = copyOfx % 10;
                copyOfx /= 10;
                xAddedReversely += currentDigit * (int)Math.Pow(10, i - 1);
            }

            return xAddedReversely == x;
        }
    }
}
