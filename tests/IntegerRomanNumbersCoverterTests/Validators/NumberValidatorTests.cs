using System;
using IntegerRomanNumbersCoverter.Validators;
using IntegerRomanNumbersCoverter.Validators.Interfaces;
using NUnit.Framework;

namespace IntegerRomanNumbersCoverterTests.Validators
{
    [TestFixture]
    public class NumberValidatorTests
    {
        private INumberValidator _numberValidator;

        [SetUp]
        public void SetUp()
        {
            _numberValidator = new NumberValidator();    
        }

        [TestCase(0, ExpectedException = typeof(ArgumentException))]
        [TestCase(-1, ExpectedException = typeof(ArgumentException))]
        public void Should_throw_an_exception_if_numner_is_equal_or_less_then_0(int number)
        {
            _numberValidator.Validate(number);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void Should_validate_number_major_than_0(int number)
        {
            Assert.DoesNotThrow(() => _numberValidator.Validate(number));
        }
    }
}