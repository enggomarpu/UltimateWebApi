﻿using Shared.DTOs;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
		IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
		EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
	}
}
