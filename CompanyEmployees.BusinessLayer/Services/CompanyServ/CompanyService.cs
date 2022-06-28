using AutoMapper;
using CompanyEmployess.DAL.Repositories;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmployees.BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            IEnumerable<Company> companies = await _uow.CompanyRepository.GetAllCompaniesAsync();

            IEnumerable<CompanyDto> companiesDto = _mapper.Map<IEnumerable<Company>, List<CompanyDto>>(companies);

            return companiesDto;
        }

        public async Task<CompanyDto> GetCompanyById(Guid id)
        {
            Company company = await _uow.CompanyRepository.GetByIdAsync(id);

            CompanyDto companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public CompanyDto AddCompany(CompanyDto companyDto)
        {
            ArgumentNullException.ThrowIfNull(companyDto);

            if (string.IsNullOrWhiteSpace(companyDto.Address) || string.IsNullOrWhiteSpace(companyDto.Name))
            {
                throw new ArgumentNullException("Company name or address is null or empty");
            }

            Company company = _mapper.Map<Company>(companyDto);
            try
            {
                _uow.CompanyRepository.Add(company);

                var valami = _uow.SaveChangesRepository();
            }
            catch (Exception ex)
            {
                throw;
            }

            return _mapper.Map<CompanyDto>(company);
        }

        public async Task DeleteCompanyById(Guid id)
        {
            Company company = await _uow.CompanyRepository.GetByIdAsync(id);

            if (company != null)
            {
                _uow.CompanyRepository.Remove(company);
                _uow.SaveChangesRepository();
            }
        }

        public async Task<CompanyDto> UpdateCompany(CompanyDto companyDto)
        {
            ArgumentNullException.ThrowIfNull(companyDto);

            if (string.IsNullOrWhiteSpace(companyDto.Address) || string.IsNullOrWhiteSpace(companyDto.Name))
            {
                throw new ArgumentNullException("Company name or address is null or empty");
            }

            Company company = await _uow.CompanyRepository.GetByIdAsync(companyDto.Id);

            try
            {
                company.Address = companyDto.Address;
                company.Name = companyDto.Name;
                company.Country = companyDto.Country;

                _uow.CompanyRepository.Update(company);

                _uow.SaveChangesRepository();
            }
            catch (Exception ex)
            {
                throw;
            }

            return companyDto;
        }
    }
}
