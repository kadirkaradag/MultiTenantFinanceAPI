using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantFinanceAPI.Services.DTOs;
using MultiTenantFinanceAPI.Services.Services;

namespace MultiTenantFinanceAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly IAgreementService _agreementService;

        public AgreementsController(IAgreementService agreementService)
        {
            _agreementService = agreementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAgreements()
        {
            var agreements = await _agreementService.GetAllAgreementsAsync();
            return Ok(agreements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgreement(int id)
        {
            var agreement = await _agreementService.GetAgreementByIdAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }
            return Ok(agreement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgreement([FromBody] CreateAgreementDto agreementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAgreement = await _agreementService.CreateAgreementAsync(agreementDto);
            return CreatedAtAction(nameof(GetAgreement), new { id = createdAgreement.Id }, createdAgreement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgreement(int id, [FromBody] UpdateAgreementDto agreementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _agreementService.UpdateAgreementAsync(id, agreementDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            try
            {
                await _agreementService.DeleteAgreementAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
