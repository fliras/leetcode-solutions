namespace _06ZigzagConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the number of rows: ");
            int numberOfRows = int.Parse(Console.ReadLine());

            string convertedString = Convert(text, numberOfRows);
            Console.WriteLine($"Converted string: {convertedString}");

            Console.ReadKey();
        }

        static string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            string[] wordsOfEachRow = new string[numRows];

            int wordsCounter = 0;
            int wordsCounterModifier = 1;
            for (int i = 0; i < s.Length; i++)
            {
                wordsOfEachRow[wordsCounter] += s[i];

                bool shouldToggleModifier = i != 0 && i % (numRows - 1) == 0;
                if (shouldToggleModifier) wordsCounterModifier = -wordsCounterModifier;

                wordsCounter += wordsCounterModifier;
            }

            string finalWord = string.Empty;
            foreach (string word in wordsOfEachRow)
            {
                finalWord += word;
            }

            return finalWord;
        }
    }
}
