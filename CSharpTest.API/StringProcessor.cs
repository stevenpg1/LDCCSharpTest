using CSharpTest.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.API
{
    public class StringProcessor : IProcessor<string>
    {
        private List<string> _unwantedChars;

        public StringProcessor(List<string> unwantedChars)
        {
            _unwantedChars = unwantedChars;
        }
        public string Process(string inString)
        {
            if (String.IsNullOrEmpty(inString)) return inString;

            string outString = ChangeDollarsToPounds(inString);

            outString = RemoveUnwantedCharacters(outString, _unwantedChars);

            outString = RemoveContiguousDuplicates(outString);

            outString = TruncateTo15Chars(outString);

            return outString;
        }

        private string ChangeDollarsToPounds(string inString)
        {
            return inString.Replace('$', '£');
        }

        private string RemoveUnwantedCharacters(string inString, List<string> unwantedChars)
        {
            string outString = inString;

            foreach(var unwanted in unwantedChars)
            {
                outString = outString.Replace(unwanted, "");
            }

            return outString;
        }

        private string RemoveContiguousDuplicates(string inString)
        {
            string outString = string.Empty;

            int indexCounter = 0;
            foreach(char character in inString)
            {
                if (indexCounter == 0)
                {
                    outString += character;
                    indexCounter++;
                    continue;
                }

                char lastCharacter = Convert.ToChar(outString.Substring(outString.Length - 1, 1));

                if (character != lastCharacter)
                {
                    outString += character;
                }

                indexCounter++;
            }

            return outString;
        }

        private string TruncateTo15Chars(string inString)
        {
            int strLen = inString.Length >= 15 ? 15 : inString.Length;

            return inString.Substring(0, strLen);
        }
    }
}
