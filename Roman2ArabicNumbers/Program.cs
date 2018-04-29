using System;
using System.Linq;
using System.Collections.Generic;

namespace Roman2ArabicNumbers
{
    public class Program
    {
        static Dictionary<string, int> RomanNumbersNormal = new Dictionary<string, int>()
        {
            { "M", 1000 },
            { "D", 500 },
            { "C", 100 },
            { "L", 50 },
            { "X", 10 },
            { "V", 5 },
            { "I", 1 },
        }; // https://en.wikipedia.org/wiki/Roman_numerals

        static Dictionary<string, int> RomanNumbersSubtractive = new Dictionary<string, int>()
        {
            { "CM", 900 },
            { "CD", 400 },
            { "XC", 90 },
            { "XL", 40 },
            { "IX", 9 },
            { "IV", 4 },
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your roman number!");
            string input = Console.ReadLine();
            string result = RomanParser(input).ToString();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static int RomanParser(string input)
        {
            int result = 0;
            string inputCopy = input;
            result += ReplaceRomanNumbers(ref inputCopy, RomanNumbersSubtractive, true);
            result += ReplaceRomanNumbers(ref inputCopy, RomanNumbersNormal);
            return result;
        }

        private static int ReplaceRomanNumbers(ref string inputCopy, Dictionary<string, int> numbersDictionary, bool subtractive = false)
        {
            int result = 0;
            foreach (KeyValuePair<string, int> number in numbersDictionary)
            {
                int occurence = 0;
                if (!subtractive)
                {
                    occurence = inputCopy.Count(x => x.ToString() == number.Key); // .Replace(number.Key, number.Value.ToString());
                }
                else
                {
                    if (inputCopy.Contains(number.Key))
                    {
                        occurence++;
                    }
                }
                if (occurence > 0)
                {
                    result += occurence * number.Value;
                }
                inputCopy = inputCopy.Replace(number.Key, string.Empty);
            }

            return result;
        }
    }
}
