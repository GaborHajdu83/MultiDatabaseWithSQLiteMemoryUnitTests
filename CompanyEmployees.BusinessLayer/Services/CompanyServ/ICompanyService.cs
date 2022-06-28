using Entities.DataTransferObjects;

namespace CompanyEmployees.BusinessLayer.Services
{
    public interface ICompanyService
    {
        public Task<IEnumerable<CompanyDto>> GetCompanies();
        public Task<CompanyDto> GetCompanyById(Guid id);
        public CompanyDto AddCompany(CompanyDto companyDto);
        public Task<CompanyDto> UpdateCompany(CompanyDto companyDto);
        public Task DeleteCompanyById(Guid id);
    }
}
