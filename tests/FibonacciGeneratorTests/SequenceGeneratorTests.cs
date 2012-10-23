using System;
using System.Linq;
using FibonacciGenerator.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace FibonacciGeneratorTests
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        private IFibonacciGenerator _fibonacciGenerator;
        private IArgumentValidator _argumentValidator;
        private const long LastNumber = 1234;
        
        //By definition, the first two numbers in the Fibonacci 
        //sequence are 0 and 1 (alternatively, 1 and 1), and each subsequent 
        //number is the sum of the previous two.

        [SetUp]
        public void SetUp()
        {
            _argumentValidator = MockRepository.GenerateStub<IArgumentValidator>();

            _fibonacciGenerator = new FibonacciGenerator.FibonacciGenerator(_argumentValidator);
        }

        [Test]
        public void Should_be_able_to_generate_a_fibonacci_sequence()
        {
            _argumentValidator.Expect(validator => validator.FirstNumberIsValid(Arg<long>.Is.Anything)).Return(true);

            var result = _fibonacciGenerator.Generate(1, LastNumber);

            Assert.IsNotNull(result);
        }

        [TestCase(1, Result = 0)]
        [TestCase(100, Result = 99)]
        [TestCase(1000, Result = 999)]
        public long Should_create_the_fibonacci_sequence_starting_from_a_given_number_minus_1(long number)
        {
            _argumentValidator.Expect(validator => validator.FirstNumberIsValid(Arg<long>.Is.Anything)).Return(true);

            var result = _fibonacciGenerator.Generate(number, LastNumber);

            return result.First();
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Should_not_accept_negatives_numbers()
        {
            var argumentException = new ArgumentException();

            _argumentValidator.Expect(validator => validator.FirstNumberIsValid(Arg<long>.Is.Anything)).Throw(argumentException);
            _fibonacciGenerator.Generate(-1, 1);
        }

        [Test]
        public void Fibonaci_sequence_shoul_consist_of_subsequent_number_made_by_the_sum_of_the_previous_two()
        {
            _argumentValidator.Expect(validator => validator.FirstNumberIsValid(Arg<long>.Is.Anything)).Return(true);

            const int firstNumber = 10;
            const int secondNumber = 30;

            var fibonacci = _fibonacciGenerator.Generate(firstNumber, secondNumber);

            Assert.AreEqual(9, fibonacci.ElementAt(0));
            Assert.AreEqual(10, fibonacci.ElementAt(1));
            Assert.AreEqual(19, fibonacci.ElementAt(2));
            Assert.AreEqual(29, fibonacci.ElementAt(3));
        }
    }
}
