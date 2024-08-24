using AutoMapper;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantFinanceAPI.Services.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IAgreementRepository _agreementRepository;
        private readonly IRiskAnalysisService _riskAnalysisService;
        private readonly IMapper _mapper;
        private readonly ITenantProvider _tenantProvider;

        public IssueService(IIssueRepository issueRepository, IAgreementRepository agreementRepository, IRiskAnalysisService riskAnalysisService, IMapper mapper, ITenantProvider tenantProvider)
        {
            _issueRepository = issueRepository;
            _agreementRepository = agreementRepository;
            _riskAnalysisService = riskAnalysisService;
            _mapper = mapper;
            _tenantProvider = tenantProvider;
        }

        public async Task<Issue> GetByIdAsync(int id)
        {
            return await _issueRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            return await _issueRepository.GetAllAsync();
        }

        public async Task<Issue> CreateIssueAsync(CreateIssueDto issueDto)
        {
            var agreement = await _agreementRepository.GetByIdAsync(issueDto.AgreementId);
            if (agreement == null)
            {
                throw new KeyNotFoundException("Agreement not found");
            }

            var issue = _mapper.Map<Issue>(issueDto);
            issue.Agreement = agreement;

            var riskResult = _riskAnalysisService.AnalyzeRisk(issue);
            issue.RiskAmount = riskResult.RiskAmount;

            issue.TenantId = _tenantProvider.TenantId;

            await _issueRepository.AddAsync(issue);
            return issue;
        }

        public async Task UpdateIssueAsync(int id, UpdateIssueDto issueDto)
        {
            var existingIssue = await _issueRepository.GetByIdAsync(id);
            if (existingIssue == null)
            {
                throw new KeyNotFoundException("Issue not found");
            }

            var updatedIssue = _mapper.Map(issueDto, existingIssue);

            await _issueRepository.UpdateAsync(updatedIssue);
        }

        public async Task DeleteIssueAsync(int id)
        {
            await _issueRepository.DeleteAsync(id);
        }

        public RiskResult AnalyzeRisk(Issue issue)
        {
            return _riskAnalysisService.AnalyzeRisk(issue);
        }
    }
}
