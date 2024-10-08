﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;


namespace Presentation.Controllers
{
	[Route("api/companies/{companyId}/employees")]
	[ApiController]
	public class EmployeesController: ControllerBase
	{
		private readonly IServiceManager _service;
		public EmployeesController(IServiceManager service) => _service = service;


		[HttpGet]
		public ActionResult GetEmployeesForCompany(Guid companyId)
		{
			var employees = _service.EmployeeService.GetEmployees(companyId, false);
			return Ok(employees);
		}




	}
}
