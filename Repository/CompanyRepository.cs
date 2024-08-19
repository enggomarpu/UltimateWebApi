using Contracts;
using Entities.Modals;

namespace Repository
{
	public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{ 
		}

		public IEnumerable<Company> GetAllCompanies(bool trackChanges)
		{
			return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
		}

		public Company GetCompany(Guid id) => FindByCondition(c => c.Id.Equals(id), false).SingleOrDefault();
		
	}
}
