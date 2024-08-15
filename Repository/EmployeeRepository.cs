﻿using Contracts;
using Entities.Modals;

namespace Repository
{
	public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{ }
	}
}
