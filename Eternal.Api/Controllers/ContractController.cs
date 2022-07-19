using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController]
    [Route("contract")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService clientService)
        {
            _contractService = clientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailDto>> GetAsync([FromRoute] int id)
        {
            var output = await _contractService.GetByIdAsync(id);
            return Ok(output);
        }



        [HttpGet("process/{id}")]
        public async Task<ActionResult<ClientDetailDto>> ProcessAsync([FromRoute] int id)
        {
            var output = await _contractService.ProcessAsync(id);
            return Ok(output);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ClientPaginationDto>>> GetPaginationAsync(
            [FromQuery] int? page = null, 
            [FromQuery] string? search = null)
        {
            var output = await _contractService.GetPaginationAsync(page, search);
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<ContractDetailDto>> CreateAsync([FromBody] ContractCreationDto creatingDto)
        {
            var output = await _contractService.CreateAsync(creatingDto);
            return Ok(output);
        }

        [HttpPut]
        public async Task<ActionResult<ContractDetailDto>> UpdateAsync([FromBody] ContractUpdatingDto updatingDto)
        {
            var output = await _contractService.UpdateAsync(updatingDto);
            return Ok(output);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _contractService.DeleteAsync(id);
            return Ok();
        }
    }
}
