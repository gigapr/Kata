using System;
using FibonacciGenerator.Interfaces;

namespace FibonacciGenerator.Validators
{
    public class ArgumentValidator : IArgumentValidator
    {
        public bool FirstNumberIsValid(long firstNumber)
        {
            IsPositiveNumber(firstNumber);

            return true;
        }

        public bool SecondNumberIsValid(long firstNumber, long secondNumber)
        {
            return IsPositiveNumber(secondNumber) && IsSecondNumberMajorThanFirst(firstNumber, secondNumber);
        }

        private static bool IsSecondNumberMajorThanFirst(long firstNumber, long secondNumber)
        {
            return secondNumber > firstNumber;
        }

        private static bool IsPositiveNumber(long firstNumber)
        {
            if (firstNumber < 0)
            {
                throw new ArgumentException("Number can't be negative.");
            }

            return true;
        }
    }
}