using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories;

internal sealed class CompanyRepository:RepositoryBase<Company>, ICompanyRepository
{
    
    public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Company> GetAllCompanies(bool trackChanges)
    {
       return GetAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    }

    public Company GetCompany(Guid companyId, bool trackChanges)
    {
        return Get(c => c.Id.Equals(companyId), trackChanges).Include(x => x.Employees)
            .SingleOrDefault()!;
    }
}