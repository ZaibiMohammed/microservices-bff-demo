using BFF.Core.DTOs;
using BFF.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BFF.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly ContractApplicationService _contractService;

        public ContractsController(ContractApplicationService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<ActionResult<ContractResponse>> CreateContract([FromBody] ContractDTO contract)
        {
            try
            {
                var result = await _contractService.CreateContractAsync(contract);
                return CreatedAtAction(nameof(GetContract), new { contractId = result.ContractId }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{contractId}")]
        public async Task<ActionResult<ContractResponse>> GetContract(string contractId)
        {
            try
            {
                var contract = await _contractService.GetContractAsync(contractId);
                if (contract == null)
                    return NotFound();

                return Ok(contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}