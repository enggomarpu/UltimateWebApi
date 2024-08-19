
using System.Text.Json;

namespace Shared
{
	public class ErrorDetailsShared
	{
		public ErrorDetailsShared(int statusCode, string message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GenerateMessageStatusCode(statusCode);
		}

		public int StatusCode { get; set; }
		public string? Message { get; set; }
		public override string ToString() => JsonSerializer.Serialize(this);
		private string GenerateMessageStatusCode(int statusCode)
		{
			return statusCode switch
			{
				400 => "Bad request",
				401 => "Unauthorized",
				404 => "not found",
				500 => "internal server error",
				_ => ""
			};
		}
	}
}
