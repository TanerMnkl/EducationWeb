using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class AgencyManager : IAgencyService
    {
        private readonly IAgenciesRepository _agenciesRepository;

        public AgencyManager(IAgenciesRepository agenciesRepository)
        {
            _agenciesRepository = agenciesRepository;
        }

        public async Task CreateAsync(Agencies agencies)
        {
            await _agenciesRepository.CreateAsync(agencies);
        }

        public async Task CreateWithUrl(Agencies agencies)
        {
            await _agenciesRepository.CreateWithUrl(agencies);
        }

        public void Delete(Agencies agencies)
        {
            _agenciesRepository.Delete(agencies);
        }

        public async Task<List<Agencies>> GetAllAsync()
        {
            var result = await _agenciesRepository.GetAllAsync();
            return result;
        }

        public async Task<List<Agencies>> GetAllAgenciesAsync(bool isDeleted, bool? isActive = null)
        {
            var result = await _agenciesRepository.GetAllAgenciesAsync(isDeleted, isActive);
            return result;
        }

        public async Task<Agencies> GetByIdAsync(int id)
        {
            var result = await _agenciesRepository.GetByIdAsync(id);
            return result;
        }

        public void Update(Agencies agencies)
        {
            _agenciesRepository.Update(agencies);
        }
    }
}
