namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            int num1 = ReadInt("Input the first number: ");
            int num2 = ReadInt("Input the second number: ");

            PrintMenu();
            string choice = Console.ReadLine();
            HandleOperation(choice, num1, num2);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        static int ReadInt(string prompt)
        {
            Console.WriteLine(prompt);
            return int.Parse(Console.ReadLine());
        }

        static void PrintMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("[A]dd numbers");
            Console.WriteLine("[S]ubtract numbers");
            Console.WriteLine("[M]ultiply numbers");
        }

        static void HandleOperation(string choice, int num1, int num2)
        {
            string upperChoice = choice.ToUpper();
            if (upperChoice.Equals("A"))
                PrintSum(num1, num2);
            else if (upperChoice.Equals("S"))
                PrintSubtraction(num1, num2);
            else if (upperChoice.Equals("M"))
                PrintMultiplication(num1, num2);
            else
                Console.WriteLine("Invalid choice!");
        }

        static void PrintSum(int num1, int num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }

        static void PrintSubtraction(int num1, int num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }

        static void PrintMultiplication(int  num1, int num2)
        {
            Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
        }
    }
}
