using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SubtractionService
{
	public static class Function
	{
		[FunctionName("Subtract")]
		public static async Task<IActionResult> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest request
		) {

			string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
			dynamic data = JsonConvert.DeserializeObject(requestBody);
			int firstNumber = data?.firstNumber;
			int secondNumber = data?.secondNumber;

			int result = firstNumber - secondNumber;

			return new OkObjectResult(result);
		}
	}
}