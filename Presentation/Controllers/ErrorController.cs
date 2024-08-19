using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Shared;


namespace Presentation.Controllers
{
	[Route("errors/{code}")]
	public class ErrorController: BaseApiController
	{
		public IActionResult Error(int code)
		{
			return new ObjectResult(new ErrorDetailsShared(code));
			
		}
	}
}
