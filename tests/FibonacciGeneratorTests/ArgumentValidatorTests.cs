using System;
using FibonacciGenerator.Interfaces;
using FibonacciGenerator.Validators;
using NUnit.Framework;

namespace FibonacciGeneratorTests
{
    [TestFixture]
    public class ArgumentValidatorTests
    {
        private IArgumentValidator _argumentValidator;

        [SetUp]
        public void SetUp()
        {
            _argumentValidator = new ArgumentValidator();
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Should_throw_an_exception_if_firstnumber_is_negative()
        {
            _argumentValidator.FirstNumberIsValid(-1);
        }

        [TestCase(1, Result = true)]
        [TestCase(6, Result = true)]
        public bool Should_return_true_if_firstnumber_is_positive_numbers(long number)
        {
            return _argumentValidator.FirstNumberIsValid(number);
        }

        [Test]
        public void Should_return_true_if_firstnumber_is_zero()
        {
            var isValid = _argumentValidator.FirstNumberIsValid(0);

            Assert.IsTrue(isValid);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Should_throw_an_exception_if_secondnumber_is_negative()
        {
            _argumentValidator.SecondNumberIsValid(0, -1);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Should_throw_an_exception_if_secondnumber_is_minor_then_firstnumber()
        {
            _argumentValidator.SecondNumberIsValid(0, -1);
        }
    }
}