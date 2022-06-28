using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployess.DAL.Repositories.CompanyRepo
{
    public class CompanyRepository : RepositoryBase<RepositoryContext, Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            List<Company> companies = await _context.Companies.Include(e => e.Employees).ToListAsync();

            return companies;
        }
    }
}
