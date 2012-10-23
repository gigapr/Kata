using IntegerRomanNumbersCoverter;
using IntegerRomanNumbersCoverter.Interfaces;
using IntegerRomanNumbersCoverter.Validators.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace IntegerRomanNumbersCoverterTests
{
    [TestFixture]
    public class ConverterTests
    {
        private INumbersConverter _numbersConverter;
        private INumberValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = MockRepository.GenerateMock<INumberValidator>();

            _numbersConverter = new NumbersConverter(_validator);
        }

        [Test]
        public void Should_be_able_to_convert_an_integer_to_its_roman_representation()
        {
            const int number = 1;

            var romanNumber = _numbersConverter.ToRoman(number);

            Assert.IsNotNull(romanNumber);
        }

        [TestCase(1, Result = "I")]
        [TestCase(3, Result = "III")]
        [TestCase(5, Result = "V")]
        [TestCase(10, Result = "X")]
        [TestCase(49, Result = "XLIX")]
        [TestCase(50, Result = "L")]
        [TestCase(100, Result = "C")]
        [TestCase(291, Result = "CCXCI")]
        [TestCase(490, Result = "CDXC")]
        [TestCase(500, Result = "D")]
        [TestCase(950, Result = "CML")]
        [TestCase(999, Result = "CMXCIX")]
        [TestCase(1000, Result = "M")]
        [TestCase(1910, Result = "MCMX")]
        [TestCase(1954, Result = "MCMLIV")]
        [TestCase(1990, Result = "MCMXC")]
        [TestCase(1999, Result = "MCMXCIX")]
        public string Should_return_a_number_corresponding_roman_representation(int number)
        {
            return _numbersConverter.ToRoman(number);
        }

        [Test]
        public void Should_validate_numbers_to_convert()
        {
            const int number = 1;

            _validator.Expect(validator => validator.Validate(number));

            _numbersConverter.ToRoman(number);

            _validator.VerifyAllExpectations();
        }
    }
}
