using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterMappings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Is mappable
            Console.WriteLine("Mappable string pairs:");
            DisplayResults("abg", "bcd");
            DisplayResults("abca", "zyxy");
            DisplayResults("ccba", "zyxy");
            DisplayResults("yeeeee", "haaaaa");
            DisplayResults("alex", "neat");
            DisplayResults("Alex", "neat");
            DisplayResults("1234", "plot");
            DisplayResults("1233", "cool");

            // Is not mappable
            Console.WriteLine("");
            Console.WriteLine("Not mappable string pairs:");
            DisplayResults("Alex", "cool"); // 😢
            DisplayResults("foo", "bar");
            DisplayResults("foo", "ba");
        }

        static void DisplayResults(string first, string second)
        {
            var isMappable = CheckIfStringsAreMappable(first, second);
            Console.WriteLine($"{string.Join("", first)} {(isMappable ? "is" : "is not")} mappable to {string.Join("", second)}");
        }

        // Checks if a string is one-to-one mappable to another
        static bool CheckIfStringsAreMappable(string first, string second)
        {
            // Check that strings are instantiated and the same length
            if ((first == null || second == null) || first.Length != second.Length)
            {
                return false;
            }

            // Create dictionary of character counts for both strings
            var firstCountDict = new Dictionary<char, int>();
            var secondCountDict = new Dictionary<char, int>();
            void AddToDictionary(Dictionary<char, int> dictionary, char character)
            {
                if (dictionary.ContainsKey(character))
                {
                    dictionary[character]++;
                }
                else
                {
                    dictionary.Add(character, 1);
                }
            }
            foreach (var character in first)
            {
                AddToDictionary(firstCountDict, character);
            }
            foreach (var character in second)
            {
                AddToDictionary(secondCountDict, character);
            }

            // Check that the number of unique characters is the same
            if (firstCountDict.Count != secondCountDict.Count)
            {
                return false;
            }

            // Check that the sorted unique character counts are the same - if so, the strings are one-to-one mappable.
            var firstCharacterCounts = firstCountDict.Values.OrderBy(x => x);
            var secondCharacterCounts = secondCountDict.Values.OrderBy(x => x);
            for (int i = 0; i < firstCharacterCounts.Count(); i++)
            {
                if (firstCharacterCounts.ElementAt(i) != secondCharacterCounts.ElementAt(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
