using CSharpTest.API;
using CSharpTest.API.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CSharpTest.Test
{
    [TestClass]
    public class StringCollectionProcessorTests
    {
        private IProcessor<string> stringProcessor;
        private ICollectionProcessor<string> collectionProcessor;

        [TestInitialize]
        public void Initialise()
        {
            List<string> unwantedChars = new List<string>();
            unwantedChars.Add("4");
            unwantedChars.Add("_");
            stringProcessor = new StringProcessor(unwantedChars);
            collectionProcessor = new StringCollectionProcessor(stringProcessor);
            // var inputString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
        }

        [TestMethod]
        public void StringCollectionProcessorShouldNeverBeNullEvenWhenGivenNoInput()
        {
            List<string> outputCollection = collectionProcessor.Process(null);

            Assert.IsNotNull(outputCollection);
        }

        [TestMethod]
        public void StringCollectionProcessorShouldNeverReturnNullOrEmptyStringsEvenWhenGivenNoInputItShouldReturnLengthZero()
        {
            List<string> outputCollection = collectionProcessor.Process(null);

            Assert.AreEqual(0, outputCollection.Count);
        }

        [TestMethod]
        public void StringCollectionProcessorShouldNeverReturnNullOrEmptyStringsWhenGivenNullOrEmptyStringItShouldDiscardThem()
        {
            List<string> inputCollection = new List<string>();
            inputCollection.Add(null);
            inputCollection.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");
            inputCollection.Add("");

            List<string> outputCollection = collectionProcessor.Process(inputCollection);

            Assert.AreEqual(1, outputCollection.Count);
            Assert.AreEqual("Ac91%cWwWkLq£1c", outputCollection[0]);
        }
    }
}
