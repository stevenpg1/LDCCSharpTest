using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTest.API.Interfaces
{
    public interface IProcessor<T>
    {
        T Process(T inString);
    }
}
