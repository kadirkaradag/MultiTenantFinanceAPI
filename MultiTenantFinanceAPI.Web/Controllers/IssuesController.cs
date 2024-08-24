using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Services.DTOs;
using MultiTenantFinanceAPI.Services.Services;

namespace MultiTenantFinanceAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;

        public IssuesController(IIssueService issueService, IMapper mapper)
        {
            _issueService = issueService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssue(int id)
        {
            var issue = await _issueService.GetByIdAsync(id);            

            if (issue == null)
            {
                return NotFound();
            }

            var issueDto = _mapper.Map<IssueDto>(issue); // Issue -> IssueDto dönüştürmesi
            return Ok(issueDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueDto createIssueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Servis metoduna DTO'yu geçiyoruz
            var createdIssue = await _issueService.CreateIssueAsync(createIssueDto);

            // Oluşturulan Issue'yu IssueDto'ya dönüştürüyoruz
            var issueDto = _mapper.Map<IssueDto>(createdIssue);

            return CreatedAtAction(nameof(GetIssue), new { id = createdIssue.Id }, issueDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIssue(int id, [FromBody] UpdateIssueDto updateIssueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingIssue = await _issueService.GetByIdAsync(id);
            if (existingIssue == null)
            {
                return NotFound();
            }

            await _issueService.UpdateIssueAsync(id, updateIssueDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var existingIssue = await _issueService.GetByIdAsync(id);
            if (existingIssue == null)
            {
                return NotFound();
            }

            await _issueService.DeleteIssueAsync(id);
            return NoContent();
        }

    }

}
