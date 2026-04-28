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

        [HttpPost("{id}/addresses")]
        public async Task<IActionResult> AddAddress(int id, ClientAddress address)
        {
            if (id != address.ClientId) return BadRequest("Niezgodność ID klienta.");

            try
            {
                await _clientService.AddAddressAsync(id, address);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Błąd serwera: {ex.Message}");
            }
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

        [HttpPut("addresses/{addressId}")]
        public async Task<IActionResult> UpdateAddress(int addressId, ClientAddress address)
        {
            if (addressId != address.Id) return BadRequest("Niezgodność ID adresu");
            await _clientService.UpdateAddressAsync(address);
            return NoContent();
        }

        [HttpDelete("addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            await _clientService.DeleteAddressAsync(addressId);
            return NoContent();
        }
    }
}

