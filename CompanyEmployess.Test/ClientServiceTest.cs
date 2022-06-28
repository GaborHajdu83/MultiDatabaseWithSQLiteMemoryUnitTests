using AutoMapper;
using CompanyEmployees.BusinessLayer.MappingConfiguration;
using CompanyEmployees.BusinessLayer.Services.ClientServ;
using CompanyEmployess.DAL;
using CompanyEmployess.DAL.Repositories;
using CompanyEmployess.Test.DbSQLiteFactory;
using Entities.DataTransferObjects;
using System;
using Xunit;

namespace CompanyEmployess.Test
{
    public class ClientServiceTest
    {
        private SQLiteFactory _sqliteFactory;
        private RepositoryContext _repositoryContext;
        private ExternalClientContext _externalClientContext;

        private IClientService _clientService;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ClientServiceTest()
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

            _clientService = new ClientService(_unitOfWork, _mapper);
        }

        [Fact]
        public void GetClients_WithResponse_Test()
        {
            var result = _clientService.GetClients();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetClientById_WithResponse_Test()
        {
            var result = _clientService.GetClientById(new Guid("C1F33503-BB38-4FA1-98A0-6CFAF9986797")).GetAwaiter().GetResult();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetClientById_WithoutResponse_Test()
        {
            var result = _clientService.GetClientById(new Guid("01F33503-BB38-4FA1-98A0-6CFAF9986797")).GetAwaiter().GetResult();

            Assert.Null(result);
        }

        [Fact]
        public void AddClient_WithResponse_Test()
        {
            ClientDto companyDto = new ClientDto
            {
                Name = "Lángos sütöde",
            };

            var result = _clientService.AddClient(companyDto);

            Assert.NotEqual(default(Guid), result.Id);
        }

        [Fact]
        public void DeleteClientById_Test()
        {
            _clientService.DeleteClientById(new Guid("C1F33503-BB38-4FA1-98A0-6CFAF9986797")).GetAwaiter().GetResult();

            var result = _clientService.GetClientById(new Guid("C1F33503-BB38-4FA1-98A0-6CFAF9986797")).GetAwaiter().GetResult();

            Assert.Null(result);
        }
    }
}
