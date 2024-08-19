using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
			_mapper = mapper;
		}

		public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
		{
			var company = _repository.Company.GetCompany(companyId);
			if (company == null) {
				throw new ResourceNotFoundException(companyId, "Employee", 404);
			
			}

			var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
			var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

			return employeesDto;
		}

		public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
		{
			var company = _repository.Company.GetCompany(companyId);
			if (company is null)
				throw new ResourceNotFoundException(companyId, "Company", 404);
			
			var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges);
			if (employeeDb is null)
				throw new ResourceNotFoundException(companyId, "Employee", 404);
			var employee = _mapper.Map<EmployeeDto>(employeeDb);
			return employee;
		}



	}
}