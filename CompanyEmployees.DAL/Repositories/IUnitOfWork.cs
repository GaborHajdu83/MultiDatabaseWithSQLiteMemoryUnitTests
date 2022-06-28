using CompanyEmployess.DAL.Repositories.ClientRepo;
using CompanyEmployess.DAL.Repositories.CompanyRepo;
using CompanyEmployess.DAL.Repositories.EmployeeRepo;

namespace CompanyEmployess.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        IClientRepository ClientRepository { get; }

        bool SaveChangesRepository();
        Task<bool> SaveChangesAsyncRepository();

        bool SaveChangesClient();
        Task<bool> SaveChangesAsyncClient();
    }
}
