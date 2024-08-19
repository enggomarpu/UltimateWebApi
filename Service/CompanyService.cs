using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DTOs;


namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public CompanyService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
			_mapper = mapper;
		}

		public CompanyDto GetCompany(Guid companyId) {
			try
			{
				var company = _repository.Company.GetCompany(companyId);
				if (company != null)
				{
					
					var companyDto = _mapper.Map<CompanyDto>(company);
					return companyDto;
				}
				throw new ResourceNotFoundException(companyId, "Company", 404);

			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
				throw;
			}
		}

		public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
		{
			try
			{
				var companies = _repository.Company.GetAllCompanies(trackChanges);

				var companiesDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
				return companiesDtos;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies)} service method { ex}");
			throw;
			}
		}
	}
}