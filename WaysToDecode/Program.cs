using System;
using System.Collections.Generic;
using System.Linq;

namespace CharacterMappings
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayResults("111");
            DisplayResults("110");
            DisplayResults("123");
            DisplayResults("222");
            DisplayResults("229");
            DisplayResults("2222");
            DisplayResults("222222");
            DisplayResults("2256789");
            DisplayResults("925216789");
        }

        static void DisplayResults(string encodedMessage)
        {
            int waysToDecode = GetWaysToDecodeCount(encodedMessage);
            Console.WriteLine($"{string.Join("", encodedMessage)} is decodeable in {waysToDecode} ways.");
        }

        //// Checks how many ways a string can be decoded
        //static int GetWaysToDecodeCount(string encodedMessage)
        //{
        //    int waysToDecodeCount = 1;
        //    for (int i = 0; i < encodedMessage.Length - 1; i++)
        //    {
        //        var nextTwoCharsInt = int.Parse(encodedMessage.ElementAt(i).ToString() + encodedMessage.ElementAt(i + 1).ToString());
        //        // Check if current character + next character is a valid multi-character encoding (between 10-26)
        //        if (nextTwoCharsInt >= 10 && nextTwoCharsInt <= 26)
        //        {
        //            waysToDecodeCount++;
        //        }
        //    }
        //    return waysToDecodeCount;
        //}

        // Checks how many ways a string can be decoded
        static int GetWaysToDecodeCount(string encodedMessage)
        {
            int waysToDecodeCount = 1;

            if (encodedMessage.Length == 0)
            {
                return waysToDecodeCount;
            }

            //string naiveDecoding = "";
            Dictionary<int, string> decodings = new Dictionary<int, string>();
            for (int i = 0; i < encodedMessage.Length; i++)
            {
                //var currentNumberString = encodedMessage.ElementAt(i).ToString();
                //// Naive decoding - assume everything is first decodeable character
                //naiveDecoding += (char)(int.Parse(currentNumberString) + 96);

                if (i + 1 < encodedMessage.Length)
                {
                    int firstInt = int.Parse(encodedMessage.ElementAt(i).ToString());
                    int secondInt = int.Parse(encodedMessage.ElementAt(i + 1).ToString());
                    var nextTwoInt = int.Parse(encodedMessage.ElementAt(i).ToString() + encodedMessage.ElementAt(i + 1).ToString());
                    // Check if current character starts with 1 or 2 and is not end of string (can be decoded in multiple ways)
                    if (nextTwoInt >= 10 && nextTwoInt <= 26)
                    {
                        char firstChar = (char)(firstInt + 96);
                        char secondChar = (char)(secondInt + 96);
                        string decoding = new string(new char[] { firstChar, secondChar });
                        decodings.Add(i, decoding);
                    }
                }
            }

            // Construct all possible decodings from list of decodings - start with 1 possible from naive approach
            var possibleDecodings = 1;
            for (int i = 0; i < decodings.Count; i++)
            {
                // Each possible decoding adds at least 1 possible permutation if the next character is not a 0
                if (!(int.Parse(encodedMessage.ElementAt(decodings.ElementAt(i).Key + 1).ToString()) == 0))
                {
                    possibleDecodings++;
                }
                // Look for multiple allowed decodings later in string
                for (int j = i + 1; j < decodings.Count; j++)
                {
                    if (j < decodings.Count && (decodings.ElementAt(i).Key + 1 < decodings.ElementAt(j).Key))
                    {
                        // Multiple possible permutations 
                        possibleDecodings++;
                    }
                }
            }

            return possibleDecodings;
        }

    }
}
