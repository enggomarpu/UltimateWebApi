namespace Entities.Exceptions
{
	public abstract class NotFoundException : Exception
	{
		public int statusCode { get; }
		public NotFoundException(string message, int sCode) : base(message) 
		{
			statusCode = sCode;
		}
	}
}
