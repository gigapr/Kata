using System;
using IntegerRomanNumbersCoverter.Enums;
using IntegerRomanNumbersCoverter.Interfaces;
using IntegerRomanNumbersCoverter.Validators.Interfaces;

namespace IntegerRomanNumbersCoverter
{
    public class NumbersConverter : INumbersConverter
    {
        private readonly INumberValidator _validator;

        public NumbersConverter(INumberValidator validator)
        {
            _validator = validator;
        }

        public string ToRoman(int number)
        {
            _validator.Validate(number);

            var romanRepresentation = string.Empty;

            var values = Enum.GetValues(typeof(RomanNumber));

            for (var i = values.Length - 1; i >= 0; --i)
            {
                var value = (int)values.GetValue(i);

                while (number >= value)
                {
                    romanRepresentation += Enum.GetName(typeof(RomanNumber), value);

                    number -= value;
                }
            }
            
            return romanRepresentation;
        }
    }
}