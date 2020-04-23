using CSharpTest.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.API
{
    public class StringCollectionProcessor : ICollectionProcessor<string>
    {
        private IProcessor<string> _stringProcessor;

        public StringCollectionProcessor(IProcessor<string> stringProcessor)
        {
            _stringProcessor = stringProcessor;
        }

        public List<string> Process(IEnumerable<string> collection)
        {
            List<string> rtnCollection = new List<string>();
            if (collection == null) return rtnCollection;

            foreach(var item in collection)
            {
                string outString = _stringProcessor.Process(item);
                if (!String.IsNullOrEmpty(outString))
                {
                    rtnCollection.Add(outString);
                }
            }

            return rtnCollection;
        }
    }
}
