using System.Collections.Generic;
using System.Linq;
using FibonacciGenerator.Interfaces;

namespace FibonacciGenerator
{
    public class FibonacciGenerator : IFibonacciGenerator
    {
        private readonly IArgumentValidator _argumentValidator;

        public FibonacciGenerator(IArgumentValidator argumentValidator)
        {
            _argumentValidator = argumentValidator;
        }

        public IList<long> Generate(long firstNumber, long lastNumber)
        {
            List<long> fibonacciSequence = null;
            
            if(_argumentValidator.FirstNumberIsValid(firstNumber))
            {
                long previousNumber = 0;
            
                if(firstNumber != 0)
                {
                    previousNumber = firstNumber - 1;
                }
                
                var currentNumber  = firstNumber;

                fibonacciSequence = new List<long>{ previousNumber };
                
                while (currentNumber <= lastNumber)
                {
                    fibonacciSequence.Add(currentNumber);

                    previousNumber = fibonacciSequence.ElementAt(fibonacciSequence.Count - 1);
                    currentNumber  = fibonacciSequence.ElementAt(fibonacciSequence.Count - 2) + previousNumber;
                }
            }

            return fibonacciSequence;
        }
    }
}