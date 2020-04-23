using CSharpTest.API;
using CSharpTest.API.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CSharpTest.Test
{
    [TestClass]
    public class StringProcessorTests
    {
        private IProcessor<string> stringProcessor;

        [TestInitialize]
        public void Initialise()
        {
            List<string> unwantedChars = new List<string>();
            unwantedChars.Add("4");
            unwantedChars.Add("_");
            stringProcessor = new StringProcessor(unwantedChars);
        }

        [TestMethod]
        public void StringProcessorShouldReturnNoMoreThan15CharactersWhenGivenAStringOfMoreThan15Characters()
        {
            var inputString = "AAAc91%cWwWkLq$1ci3_848v3d__K";
            var outputString = stringProcessor.Process(inputString);

            Assert.IsTrue(outputString.Length <= 15);
        }

        [TestMethod]
        public void StringProcessorShouldReturnNoMoreThan15CharactersWhenGivenAStringOfExactly15Characters()
        {
            var inputString = "AbLKJ1213SsDFsf";
            var outputString = stringProcessor.Process(inputString);

            Assert.IsTrue(outputString.Length <= 15);
        }

        [TestMethod]
        public void StringProcessorShouldRemoveAnyDuplicateContinguousCharsRespectingCaseAsDifferentGiven3CapAReturn1()
        {
            var inputString = "AAA";
            var outputString = stringProcessor.Process(inputString);

            Assert.AreEqual("A", outputString);
        }

        [TestMethod]
        public void StringProcessorShouldRemoveAnyDuplicateContinguousCharsRespectingCaseAsDifferentGivenAaAReturnAaA()
        {
            var inputString = "AaA";
            var outputString = stringProcessor.Process(inputString);

            Assert.AreEqual("AaA", outputString);
        }


        [TestMethod]
        public void StringProcessorShouldRemoveAny4sOrUnderscores()
        {
            var inputString = "AaA_4r5__82746";
            var outputString = stringProcessor.Process(inputString);

            Assert.AreEqual("AaAr58276", outputString);
        }

        [TestMethod]
        public void StringProcessorShouldReplaceDollarSignsWithPoundSigns()
        {
            var inputString = "AaA_4r5_$82746$";
            var outputString = stringProcessor.Process(inputString);

            Assert.AreEqual("AaAr5£8276£", outputString);
        }

        [TestMethod]
        public void StringProcessorShouldRemoveAnyDuplicateContinguousCharsRespectingCaseAsDifferentWhenRemoving4sAndUnderscoresCreatesNewContiguousDuplicates()
        {
            var inputString = "AAAc91_cWwWk_848";
            var outputString = stringProcessor.Process(inputString);

            Assert.AreEqual("Ac91cWwWk8", outputString);
        }
    }
}
