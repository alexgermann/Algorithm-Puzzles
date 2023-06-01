using System;
using System.Collections.Generic;

namespace LongestConsecutiveSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testInput = new int[] { 100, 4, 200, 1, 3, 2 };
            //testInput = new int[] { 8, 100, 4, 200, 1, 3, 2, 5, 6, 7, 99, 101, 102, 103, 104, 106, 105 };

            var length = GetLongestSubsequenceLength(testInput);
            Console.WriteLine("<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>");
            Console.WriteLine($"| Longest consecutive element sequence is length {length} |");
            Console.WriteLine("<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>:<:>");
        }

        public static int GetLongestSubsequenceLength(int[] input)
        {
            // Store array in hashset to lookup by value in O(1)
            HashSet<int> hashes = new HashSet<int>(input);
            var longCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentValue = input[i];
                if (!hashes.Contains(currentValue - 1))
                {
                    // Preceding value not found, this is the start of a subsequence. Let's find the length of it
                    var count = 0;
                    while (hashes.Contains(currentValue))
                    {
                        count++;
                        currentValue++;
                    }
                    // Update longest sequence count if this subsequence was longer
                    longCount = Math.Max(longCount, count);
                }
            }
            return longCount;
        }
    }
}
