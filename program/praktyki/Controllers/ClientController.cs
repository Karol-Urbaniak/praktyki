using Microsoft.AspNetCore.Mvc;
using praktyki.Models;
using praktyki.Services;

namespace praktyki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(int id)
        {
            var clients = await _clientService.GetClientByIdAsync(id);
            if (clients == null) return NotFound();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            await _clientService.CreateClientAsync(client);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client client)
        {
            try
            {
                await _clientService.UpdateClientAsync(id, client);
            }
            catch (ArgumentException)
            {
                return BadRequest("Niepoprawnie dobrane ID");
            }

            return NoContent();
        }
    }
}

