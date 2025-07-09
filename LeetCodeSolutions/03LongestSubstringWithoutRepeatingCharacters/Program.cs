namespace _03LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(LengthOfLongestSubstring("dvdf"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbbb"));
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
            Console.ReadKey();
        }

        static int LengthOfLongestSubstring(string s)
        {
            int longestLength = 0;
            int start = 0;
            Dictionary<string, bool> substringChars = new Dictionary<string, bool>();

            for (int i = 0; i < s.Length; i++)
            {
                string letter = s[i].ToString();
                if (substringChars.ContainsKey(letter))
                {
                    longestLength = Math.Max(longestLength, substringChars.Count);
                    substringChars.Clear();
                    i = start;
                    start++;
                }
                else
                {
                    substringChars.Add(letter, true);
                }
            }

            return Math.Max(longestLength, substringChars.Count);
        }
    }
}
