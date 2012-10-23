using System;
using IntegerRomanNumbersCoverter.Validators.Interfaces;

namespace IntegerRomanNumbersCoverter.Validators
{
    public class NumberValidator : INumberValidator
    {
        public void Validate(int number)
        {
            if(number <= 0)
            {
                var message = string.Format("{0} is not a valid number. It must be bbigger than 0.", number);

                throw new ArgumentException(message);
            }
        }
    }
}