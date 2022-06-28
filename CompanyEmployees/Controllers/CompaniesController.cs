using AutoMapper;
using CompanyEmployees.BusinessLayer.Services;
using CompanyEmployess.DAL.Repositories;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get-companies")]
        public async Task<IActionResult> GetCompanies()
        {
            IEnumerable<CompanyDto> companies = await _companyService.GetCompanies();

            return Ok(companies);
        }

        [HttpGet("get-company-by-id/{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            CompanyDto companyDto = await _companyService.GetCompanyById(id);

            return Ok(companyDto);
        }

        [HttpPost("add-company")]
        public CompanyDto AddCompany([FromBody] CompanyDto companyDto)
        {
            CompanyDto result = _companyService.AddCompany(companyDto);

            return result;
        }

        [HttpPut("update-company")]
        public async Task<CompanyDto> UpdateCompany([FromBody] CompanyDto companyDto)
        {
            CompanyDto result = await _companyService.UpdateCompany(companyDto);
            return result;
        }

        [HttpDelete("delete-company-by-id/{id}")]
        public async Task<IActionResult> DeleteCompanyById(Guid id)
        {
            await _companyService.DeleteCompanyById(id);

            return Ok();
        }
    }
}