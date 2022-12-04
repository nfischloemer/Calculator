namespace Calculator.Services
{
	public interface ISubtractionService
	{
		Task<int> Subtract(int firstNumber, int secondNumber);
	}
}
