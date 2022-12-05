namespace Calculator.Services
{
	public class SubtractionService : ISubtractionService
	{
		private readonly HttpClient _httpClient;

		public SubtractionService(IConfiguration config, HttpClient httpClient) {
			var subtractionServiceUrl = config["SubtractionServiceUrl"]
				?? throw new ArgumentNullException("SubtractionServiceUrl");
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(subtractionServiceUrl);
		}

		public async Task<int> Subtract(int firstNumber, int secondNumber) {
			var content = new	{ firstNumber = firstNumber, secondNumber = secondNumber };
			var response = await _httpClient.PostAsJsonAsync("", content);

			while(!response.IsSuccessStatusCode) {
				Thread.Sleep(5000);
				response = await _httpClient.PostAsJsonAsync("", content);
			}

			return int.Parse(await response.Content.ReadAsStringAsync());
		}
	}
}