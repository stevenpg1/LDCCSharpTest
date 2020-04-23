using CSharpTest.API;
using CSharpTest.API.Interfaces;
using System;
using System.Collections.Generic;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<string> unwantedChars = new List<string>();
            unwantedChars.Add("4");
            unwantedChars.Add("_");
            IProcessor<string> stringProcessor = new StringProcessor(unwantedChars);
            ICollectionProcessor<string> collectionProcessor = new StringCollectionProcessor(stringProcessor);

            string inputString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
            List<string> inputCollection = new List<string>();
            inputCollection.Add(inputString);
            List<string> outputCollection = collectionProcessor.Process(inputCollection);

            foreach(var item in outputCollection)
            {
                Console.WriteLine($"Next string is: {item}");
            }

            Console.ReadLine();
        }
    }
}
