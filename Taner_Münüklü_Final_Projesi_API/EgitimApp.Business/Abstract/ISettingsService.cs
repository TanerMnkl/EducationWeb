using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Abstract
{
    public interface ISettingsService
    {
        #region Generic
        Task<Response<SettingsDto>> GetByIdAsync(int? id);
        Task<Response<List<SettingsDto>>> GetAllAsync();
        Task<Response<SettingsDto>> CreateAsync(SettingsCreateDto settingsCreateDto);
        Task<Response<NoContent>> UpdateAsync(SettingsDto settings);
        Task<Response<NoContent>> DeleteAsync(int id);
        #endregion
    }
}
