namespace _07ReverseInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a number: ");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine($"Reverse number: {Reverse(input)}");
            Console.ReadKey();
        }

        static int Reverse(int x)
        {
            int signalToggler = x < 0 ? -1 : 1;
            int numberOfDigits = (int)Math.Floor(Math.Log10(x * signalToggler) + 1);
            if (numberOfDigits == 1)
                return x;

            int numberToReverse = x;
            long reverseNumber = 0;

            while (numberOfDigits >= 1)
            {
                int lastDigit = numberToReverse % 10;
                reverseNumber += (long)(lastDigit * Math.Pow(10, numberOfDigits - 1));
                if (reverseNumber < Int32.MinValue || reverseNumber > Int32.MaxValue)
                    return 0;

                numberToReverse /= 10;
                numberOfDigits--;
            }

            return (int)reverseNumber;
        }
    }
}
