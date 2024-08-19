﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers
{
	
	public class CompaniesController : BaseApiController
	{
		private readonly IServiceManager _service;

		public CompaniesController(IServiceManager service)
		{
			_service = service;
		}
		[HttpGet]
		public IActionResult GetCompanies(){

				var companies = _service.CompanyService.GetAllCompanies(false);
				return Ok(companies);
			
			
		}
		[HttpGet("{id:guid}")]
		public IActionResult GetCompany(Guid id)
		{
			var company = _service.CompanyService.GetCompany(id);
			return Ok(company);
		}
	}
}
