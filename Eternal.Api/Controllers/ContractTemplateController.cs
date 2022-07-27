using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("contract-template")]
    public class ContractTemplateController : ControllerBase
    {
        private readonly IContractTemplateService _contractTemplateService;

        public ContractTemplateController(IContractTemplateService contractTemplateService)
        {
            _contractTemplateService = contractTemplateService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractTemplateDetailDto>> GetAsync([FromRoute] int id)
        {
            var output = await _contractTemplateService.GetByIdAsync(id);
            return Ok(output);
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ContractTemplatePaginationDto>>> GetPaginationAsync(
            [FromQuery] int? page = null,
            [FromQuery] string? search = null)
        {
            var output = await _contractTemplateService.GetPaginationAsync(page, search);
            return Ok(output);
        }

        [HttpOptions]
        public async Task<ActionResult<List<ContractTemplateOptionDto>>> GetOptions()
        {
            var output = await _contractTemplateService.GetOptionsAsync();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<ContractTemplateDetailDto>> CreateAsync([FromBody] ContractTemplateCreationDto creatingDto)
        {
            var output = await _contractTemplateService.CreateAsync(creatingDto);
            return Ok(output);
        }

        [HttpPut]
        public async Task<ActionResult<ContractTemplateDetailDto>> UpdateAsync([FromBody] ContractTemplateUpdatingDto updatingDto)
        {
            var output = await _contractTemplateService.UpdateAsync(updatingDto);
            return Ok(output);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _contractTemplateService.DeleteAsync(id);
            return Ok();
        }

    }
}
