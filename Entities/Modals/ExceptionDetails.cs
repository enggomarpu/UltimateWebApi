namespace Entities.Modals
{
	public class ExceptionDetails : ErrorDetails
	{
		public ExceptionDetails(int statusCode, string message = null, string det = null) : base(statusCode, message)
		{
			details = det;
		}

		public string details { get; set; }
	}
}
