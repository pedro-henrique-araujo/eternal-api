using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailDto>> GetAsync([FromRoute] int id)
        {
            var output = await _clientService.GetByIdAsync(id);
            return Ok(output);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ClientPaginationDto>>> GetPaginationAsync(
            [FromQuery] int? page = null,
            [FromQuery] string? search = null)
        {
            var output = await _clientService.GetPaginationAsync(page, search);
            return Ok(output);
        }

        [HttpOptions]
        public async Task<ActionResult<List<ClientOptionDto>>> GetOptions()
        {
            var output = await _clientService.GetOptionsAsync();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDetailDto>> CreateAsync([FromBody] ClientCreationDto creatingDto)
        {
            var output = await _clientService.CreateAsync(creatingDto);
            return Ok(output);
        }

        [HttpPut]
        public async Task<ActionResult<ClientDetailDto>> UpdateAsync([FromBody] ClientUpdatingDto updatingDto)
        {
            var output = await _clientService.UpdateAsync(updatingDto);
            return Ok(output);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _clientService.DeleteAsync(id);
            return Ok();
        }
    }
}
