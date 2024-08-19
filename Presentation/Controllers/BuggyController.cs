using Microsoft.AspNetCore.Mvc;
using Service.Contracts;


namespace Presentation.Controllers
{
	public class BuggyController : BaseApiController
	{
		private readonly IServiceManager _context;

		public BuggyController(IServiceManager context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetBuggies()
		{
			List < List<int> > lists = new List<List<int>> {
	new List<int> {1, 2, 3},
	new List<int> {12},
	new List<int> {5, 6, 5, 7},
	new List<int> {10, 10, 10, 12}
};
			return Ok(lists);
		}

		[HttpGet("notfound")]
		public ActionResult GetNotFound()
		{
			var thing = _context.CompanyService.GetCompany(new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
			return Ok(thing);
		}
		[HttpGet("servererror")]
		public ActionResult GetServerError()
		{
			var thing = _context.CompanyService.GetCompany(new Guid("d9d4c053-49b6-410c-bc78-2d54a9991870"));
			var thingToString = thing.ToString();
			return Ok();
		}

		[HttpGet("badrequest")]
		public ActionResult GetBadRequest()
		{
			return BadRequest(new {StatusCode= 404, Message= "NotFound" });
		}

		[HttpGet("badrequest/{id}")]
		public ActionResult GetBadRequestId(int id)
		{
			return Ok();
		}

	}
}
