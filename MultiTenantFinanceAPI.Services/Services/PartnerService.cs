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
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IMapper _mapper;
        private readonly ITenantProvider _tenantProvider;

        public PartnerService(IPartnerRepository partnerRepository, IMapper mapper, ITenantProvider tenantProvider)
        {
            _partnerRepository = partnerRepository;
            _mapper = mapper;
            _tenantProvider = tenantProvider;
        }

        public async Task<IEnumerable<PartnerDto>> GetAllPartnersAsync()
        {
            var partners = await _partnerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PartnerDto>>(partners);
        }

        public async Task<PartnerDto> GetPartnerByIdAsync(int id)
        {
            var partner = await _partnerRepository.GetByIdAsync(id);
            return _mapper.Map<PartnerDto>(partner);
        }

        public async Task<PartnerDto> CreatePartnerAsync(CreatePartnerDto partnerDto)
        {
            var partner = _mapper.Map<Partner>(partnerDto);
            partner.TenantId = _tenantProvider.TenantId;

            await _partnerRepository.AddAsync(partner);
            return _mapper.Map<PartnerDto>(partner);
        }

        public async Task UpdatePartnerAsync(int id, UpdatePartnerDto partnerDto)
        {
            var existingPartner = await _partnerRepository.GetByIdAsync(id);
            if (existingPartner == null)
            {
                throw new KeyNotFoundException("Partner not found");
            }

            _mapper.Map(partnerDto, existingPartner);
            await _partnerRepository.UpdateAsync(existingPartner);
        }

        public async Task DeletePartnerAsync(int id)
        {
            var partner = await _partnerRepository.GetByIdAsync(id);
            if (partner == null)
            {
                throw new KeyNotFoundException("Partner not found");
            }

            await _partnerRepository.DeleteAsync(partner);
        }
    }

}
