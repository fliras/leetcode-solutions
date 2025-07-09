namespace _05LongestPalindromicSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type a text: ");
            string text = Console.ReadLine();

            string longestPalindrome = LongestPalindrome(text);
            Console.WriteLine($"The longest palindrome from this string is: {longestPalindrome}");

            Console.ReadKey();
        }

        static string LongestPalindrome(string s)
        {
            bool palindromeFound = false;
            int startOfPalindrome = 0;
            int endOfPalindrome = 0;

            for (int i = s.Length - 1; !palindromeFound && i > 0; i--)
            {
                for (int j = 0; !palindromeFound && (i + j) < s.Length; j++)
                {
                    palindromeFound = isAPalindrome(s, j, j + i);
                    if (palindromeFound)
                    {
                        startOfPalindrome = j;
                        endOfPalindrome = j + i;
                    }
                }
            }

            return s.Substring(startOfPalindrome, (endOfPalindrome - startOfPalindrome + 1));
        }

        static bool isAPalindrome(string s, int start, int end)
        {
            if (start == end || start > end) return true;
            if (s[start] != s[end]) return false;
            return isAPalindrome(s, start + 1, end - 1);
        }
    }
}
