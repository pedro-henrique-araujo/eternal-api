using Eternal.Business;
using Eternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("instalment")]
    public class InstalmentController : ControllerBase
    {
        private IInstalmentService _instalmentService;

        public InstalmentController(IInstalmentService instalmentService)
        {
            _instalmentService = instalmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstalmentDetailDto>> GetById([FromRoute] int id)
        {
            var output = await _instalmentService.GetByIdAsync(id);
            return Ok(output);
        }

        [HttpGet("by-contract/{id}")]
        public async Task<ActionResult<List<InstalmentDetailDto>>> GetByContract([FromRoute] int id)
        {
            var output = await _instalmentService.GetByContractAsync(id);
            return Ok(output);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<InstalmentDetailDto>> PayById([FromRoute] int id)
        {
            var output = await _instalmentService.PayByIdAsync(id);
            return Ok(output);
        }
    }
}
