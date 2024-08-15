﻿using Entities.Modals;

namespace Service.Contracts
{
    public interface ICompanyService
    {
		IEnumerable<Company> GetAllCompanies(bool trackChanges);
	}
}
