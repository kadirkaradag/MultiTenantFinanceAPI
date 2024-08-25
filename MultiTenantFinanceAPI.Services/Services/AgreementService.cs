using AutoMapper;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Services.DTOs;

namespace MultiTenantFinanceAPI.Services.Services
{
    public class AgreementService : IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IMapper _mapper;
        private readonly ITenantProvider _tenantProvider;

        public AgreementService(IAgreementRepository agreementRepository, IMapper mapper, ITenantProvider tenantProvider)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
            _tenantProvider = tenantProvider;
        }

        public async Task<IEnumerable<AgreementDto>> GetAllAgreementsAsync()
        {
            var agreements = await _agreementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AgreementDto>>(agreements);
        }

        public async Task<AgreementDto> GetAgreementByIdAsync(int id)
        {
            var agreement = await _agreementRepository.GetByIdAsync(id);
            return _mapper.Map<AgreementDto>(agreement);
        }

        public async Task<AgreementDto> CreateAgreementAsync(CreateAgreementDto agreementDto)
        {
            var agreement = _mapper.Map<Agreement>(agreementDto);
            agreement.TenantId = _tenantProvider.TenantId;

            await _agreementRepository.AddAsync(agreement);
            return _mapper.Map<AgreementDto>(agreement);
        }

        public async Task UpdateAgreementAsync(int id, UpdateAgreementDto agreementDto)
        {
            var existingAgreement = await _agreementRepository.GetByIdAsync(id);
            if (existingAgreement == null)
            {
                throw new KeyNotFoundException("Agreement not found");
            }

            _mapper.Map(agreementDto, existingAgreement);
            await _agreementRepository.UpdateAsync(existingAgreement);
        }

        public async Task DeleteAgreementAsync(int id)
        {
            var agreement = await _agreementRepository.GetByIdAsync(id);
            if (agreement == null)
            {
                throw new KeyNotFoundException("Agreement not found");
            }
            await _agreementRepository.DeleteAsync(id);
        }
    }

}
