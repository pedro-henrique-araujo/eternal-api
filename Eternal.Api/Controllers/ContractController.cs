using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("contract")]
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

        [HttpGet("instalments-pdf/{id}")]
        public async Task<ActionResult> GetInstalmentsPdf([FromRoute] int id)
        {
            var output = await _contractService.GetInstalmentsPdf(id);
            return File(output, "application/pdf");
        }
        
        [HttpGet("contract-pdf/{id}")]
        public async Task<ActionResult> GetContractPdf([FromRoute] int id)
        {
            var output = await _contractService.GetContractPdf(id);
            return File(output, "application/pdf");
        }

        [HttpGet("process/{id}")]
        public async Task<ActionResult> ProcessAsync([FromRoute] int id)
        {
            await _contractService.ProcessAsync(id);
            return Ok();
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
