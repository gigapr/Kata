namespace FibonacciGenerator.Interfaces
{
    public interface IArgumentValidator
    {
        bool FirstNumberIsValid(long firstNumber);
        bool SecondNumberIsValid(long secondNumber, long i);
    }
}