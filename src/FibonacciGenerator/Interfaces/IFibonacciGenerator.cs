using System.Collections.Generic;

namespace FibonacciGenerator.Interfaces
{
    public interface IFibonacciGenerator
    {
        IList<long> Generate(long firstNumber, long lastNumber);
    }
}