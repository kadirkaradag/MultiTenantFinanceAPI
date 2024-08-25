using Microsoft.AspNetCore.Mvc;
using MultiTenantFinanceAPI.Services.DTOs;
using MultiTenantFinanceAPI.Services.Services;

namespace MultiTenantFinanceAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPartners()
        {
            var partners = await _partnerService.GetAllPartnersAsync();
            return Ok(partners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartner(int id)
        {
            var partner = await _partnerService.GetPartnerByIdAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartner([FromBody] CreatePartnerDto partnerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPartner = await _partnerService.CreatePartnerAsync(partnerDto);
            return CreatedAtAction(nameof(GetPartner), new { id = createdPartner.Id }, createdPartner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartner(int id, [FromBody] UpdatePartnerDto partnerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _partnerService.UpdatePartnerAsync(id, partnerDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            try
            {
                await _partnerService.DeletePartnerAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
