using AutoMapper;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Entities.Enums;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Services.DTOs;

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
        public async Task<IEnumerable<IssueDto>> GetAllIssuesAsync()
        {
            var issues = await _issueRepository.GetAllAsync();
            return issues.Select(issue => new IssueDto
            {
                Id = issue.Id,
                Title = issue.Title,
                Description = issue.Description,
                Keywords = issue.Keywords,
                Cost = issue.Cost,
                AgreementAmount = issue.AgreementAmount,
                RiskLevel = issue.RiskLevel,
                AgreementId = issue.AgreementId,
                AgreementName = issue.Agreement.Name,
            }).ToList();
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

            var issue = new Issue
            {
                Title = issueDto.Title,
                Description = issueDto.Description,
                AgreementId = issueDto.AgreementId,
                Keywords = issueDto.Keywords,
                Cost = issueDto.Cost,
                AgreementAmount = issueDto.AgreementAmount,
            };

            issue.RiskLevel = AnalyzeRisk(issue);
            issue.TenantId = _tenantProvider.TenantId;

            await _issueRepository.AddAsync(issue);
            return issue;
        }

        public RiskLevel AnalyzeRisk(Issue issue)
        {
            // Basit bir risk analizi örneği
            var riskScore = 0;

            // Anahtar kelimeler üzerinden risk analizi
            var keywords = issue.Keywords.Split(',');
            foreach (var keyword in keywords)
            {
                if (keyword.Trim().ToLower() == "critical")
                {
                    riskScore += 5;
                }
                else if (keyword.Trim().ToLower() == "important")
                {
                    riskScore += 3;
                }
            }

            // Maliyet ve anlaşma tutarına göre risk artırımı
            if (issue.Cost > issue.AgreementAmount * 0.5m)
            {
                riskScore += 4;
            }

            // Risk seviyesini belirleme
            if (riskScore >= 8)
            {
                return RiskLevel.High;
            }
            else if (riskScore >= 4)
            {
                return RiskLevel.Medium;
            }
            else
            {
                return RiskLevel.Low;
            }
        }


        public async Task UpdateIssueAsync(int id, UpdateIssueDto issueDto)
        {
            var existingIssue = await _issueRepository.GetByIdAsync(id);
            if (existingIssue == null)
            {
                throw new KeyNotFoundException("Issue not found");
            }
            var updatedIssue = _mapper.Map(issueDto, existingIssue);
            updatedIssue.RiskLevel = AnalyzeRisk(updatedIssue);

            await _issueRepository.UpdateAsync(updatedIssue);
        }

        public async Task DeleteIssueAsync(int id)
        {
            await _issueRepository.DeleteAsync(id);
        }        
    }
}
