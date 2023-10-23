using EgitimApp.Business.Abstract;
using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Concrete
{
    public class SettingsManager : ISettingsService
    {
        public Task<Response<SettingsDto>> CreateAsync(SettingsCreateDto settingsCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<SettingsDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<SettingsDto>> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> UpdateAsync(SettingsDto settings)
        {
            throw new NotImplementedException();
        }
    }
}
