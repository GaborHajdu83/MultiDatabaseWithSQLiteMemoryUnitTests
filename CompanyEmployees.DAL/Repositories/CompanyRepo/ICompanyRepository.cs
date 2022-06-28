using Entities.Models;

namespace CompanyEmployess.DAL.Repositories.CompanyRepo
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
    }
}
