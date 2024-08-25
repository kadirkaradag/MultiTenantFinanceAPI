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

        [HttpGet]
        public async Task<IActionResult> GetAllIssues()
        {
            var issues = await _issueService.GetAllAsync();
            return Ok(issues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssue(int id)
        {
            var issue = await _issueService.GetByIdAsync(id);            

            if (issue == null)
            {
                return NotFound();
            }

            var issueDto = _mapper.Map<IssueDto>(issue);
            return Ok(issueDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] CreateIssueDto issueDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var issue = await _issueService.CreateIssueAsync(issueDto);
                return Ok(new { RiskLevel = issue.RiskLevel });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
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
