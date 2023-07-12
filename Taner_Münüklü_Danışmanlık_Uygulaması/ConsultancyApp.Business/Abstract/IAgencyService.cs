using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface IAgencyService
    {
        #region Generic
        Task<Agencies> GetByIdAsync(int id);
        Task<List<Agencies>> GetAllAsync();
        Task CreateAsync(Agencies  agencies);
        void Update(Agencies agencies);
        void Delete(Agencies agencies);

        #endregion
        #region Ajanslar
        Task<List<Agencies>> GetAllAgenciesAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Agencies agencies);
        #endregion

    }
}
