using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("dependent")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentService _dependentService;

        public DependentController(IDependentService dependentService)
        {
            _dependentService = dependentService;
        }

        [HttpGet("by-client/{id}")]
        public async Task<ActionResult<List<DependentDetailDto>>> GetByClientIdAsync([FromRoute] int id)
        {
            var output = await _dependentService.GetByClientIdAsync(id);
            return Ok(output);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DependentDetailDto>> GetAsync([FromRoute] int id)
        {
            var output = await _dependentService.GetByIdAsync(id);
            return Ok(output);
        }

        [HttpOptions]
        public async Task<ActionResult<List<DependentOptionDto>>> GetOptions()
        {
            var output = await _dependentService.GetOptionsAsync();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<DependentDetailDto>> CreateAsync([FromBody] DependentCreationDto creationDto)
        {
            var output = await _dependentService.CreateAsync(creationDto);
            return Ok(output);
        }

        [HttpPut]
        public async Task<ActionResult<ClientDetailDto>> UpdateAsync([FromBody] DependentUpdatingDto updatingDto)
        {
            var output = await _dependentService.UpdateAsync(updatingDto);
            return Ok(output);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _dependentService.DeleteAsync(id);
            return Ok();
        }

    }
}
