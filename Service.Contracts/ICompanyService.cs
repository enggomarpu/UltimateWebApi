﻿

using Shared.DTOs;

namespace Service.Contracts
{
    public interface ICompanyService
    {
		IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
		CompanyDto GetCompany(Guid id);
	}
}
