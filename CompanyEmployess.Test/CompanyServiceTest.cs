using AutoMapper;
using CompanyEmployees.BusinessLayer.MappingConfiguration;
using CompanyEmployees.BusinessLayer.Services;
using CompanyEmployess.DAL;
using CompanyEmployess.DAL.Repositories;
using CompanyEmployess.Test.DbSQLiteFactory;
using Entities.DataTransferObjects;
using System;
using Xunit;

namespace CompanyEmployess.Test
{
    public class CompanyServiceTest
    {
        private SQLiteFactory _sqliteFactory;
        private RepositoryContext _repositoryContext;
        private ExternalClientContext _externalClientContext;

        private ICompanyService _companyService;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanyServiceTest()
        {
            _sqliteFactory = new SQLiteFactory();

            _repositoryContext = _sqliteFactory.CreateRepositoryContext();
            _externalClientContext = _sqliteFactory.CreateExternalClientContext();
            TestData.RepositorySeed(_repositoryContext);
            TestData.ExternalClientSeed(_externalClientContext);

            var mapperConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CompanyProfile>();
                    cfg.AddProfile<ClientProfile>();
                });
            _mapper = mapperConfig.CreateMapper();

            _unitOfWork = new UnitOfWork(_repositoryContext, _externalClientContext);

            _companyService = new CompanyService(_unitOfWork, _mapper);
        }

        [Fact]
        public void GetCompanies_WithResponse_Test()
        {
            var result = _companyService.GetCompanies();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetCompanyById_WithResponse_Test()
        {
            var result = _companyService.GetCompanyById(new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870")).GetAwaiter().GetResult();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetCompanyById_WithoutResponse_Test()
        {
            var result = _companyService.GetCompanyById(new Guid("09D4C053-49B6-410C-BC78-2D54A9991870")).GetAwaiter().GetResult();

            Assert.Null(result);
        }

        [Fact]
        public void AddCompany_WithResponse_Test()
        {
            CompanyDto companyDto = new CompanyDto
            {
                Name = "Lángos sütöde",
                Address = "Szekszárd, Piac tér 3.",
                Country = "Magyarország"
            };

            var result = _companyService.AddCompany(companyDto);

            Assert.NotEqual(default(Guid), result.Id);
        }

        [Fact]
        public void DeleteCompanyById_Test()
        {
            _companyService.DeleteCompanyById(new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870")).GetAwaiter().GetResult();

            var result = _companyService.GetCompanyById(new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870")).GetAwaiter().GetResult();

            Assert.Null(result);
        }

        [Fact]
        public void UpdateCompany_WithResponse_Test()
        {
            CompanyDto companyDto = new CompanyDto()
            {
                Id = new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870"),
                Name = "Édes élet méhészet",
                Address = "Szekszárd, Óvoda utca 16",
                Country = "Magyarország"
            };

            _companyService.UpdateCompany(companyDto).GetAwaiter().GetResult();

            var result = _companyService.GetCompanyById(new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870")).GetAwaiter().GetResult();

            Assert.Equal("Édes élet méhészet", result.Name);
        }
    }
}