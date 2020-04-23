using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.API.Interfaces
{
    public interface ICollectionProcessor<T>
    {
        List<T> Process(IEnumerable<T> collection);
    }
}
