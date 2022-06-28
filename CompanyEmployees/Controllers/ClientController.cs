using CompanyEmployees.BusinessLayer.Services.ClientServ;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("get-clients")]
        public async Task<IActionResult> GetClients()
        {
            IEnumerable<ClientDto> companies = await _clientService.GetClients();

            return Ok(companies);
        }

        [HttpGet("get-client-by-id/{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            ClientDto companyDto = await _clientService.GetClientById(id);

            return Ok(companyDto);
        }

        [HttpPost("add-client")]
        public ClientDto AddClient([FromBody] ClientDto clientDto)
        {
            ClientDto result = _clientService.AddClient(clientDto);

            return result;
        }

        [HttpDelete("delete-client-by-id/{id}")]
        public async Task<IActionResult> DeleteClientById(Guid id)
        {
            await _clientService.DeleteClientById(id);

            return Ok();
        }
    }
}
