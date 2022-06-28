using Entities.Models;

namespace CompanyEmployess.DAL.Repositories.EmployeeRepo
{
    public class EmployeeRepository : RepositoryBase<RepositoryContext, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}
