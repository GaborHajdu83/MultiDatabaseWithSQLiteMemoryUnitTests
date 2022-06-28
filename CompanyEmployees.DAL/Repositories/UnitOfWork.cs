using CompanyEmployess.DAL.Repositories.ClientRepo;
using CompanyEmployess.DAL.Repositories.CompanyRepo;
using CompanyEmployess.DAL.Repositories.EmployeeRepo;

namespace CompanyEmployess.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly ExternalClientContext _externalClientContext;

        public ICompanyRepository CompanyRepository { get; private set; }
        public IEmployeeRepository EmployeeRepository { get; private set; }

        public IClientRepository ClientRepository { get; private set; }

        public UnitOfWork(RepositoryContext repositoryContext, ExternalClientContext externalClientContext)
        {
            _repositoryContext = repositoryContext;
            _externalClientContext = externalClientContext;

            CompanyRepository = new CompanyRepository(_repositoryContext);
            EmployeeRepository = new EmployeeRepository(_repositoryContext);
            ClientRepository = new ClientRepository(_externalClientContext);
        }

        public bool SaveChangesRepository()
        {
            return _repositoryContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsyncRepository()
        {
            return await _repositoryContext.SaveChangesAsync() > 0;
        }

        public bool SaveChangesClient()
        {
            return _externalClientContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsyncClient()
        {
            return await _externalClientContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _repositoryContext.Dispose();
            _externalClientContext.Dispose();
        }
    }
}