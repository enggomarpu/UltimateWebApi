using Entities.Modals;

namespace Contracts
{
	public interface ICompanyRepository
	{
		IEnumerable<Company> GetAllCompanies(bool trackChanges);
		Company GetCompany(Guid id);
	}
}
