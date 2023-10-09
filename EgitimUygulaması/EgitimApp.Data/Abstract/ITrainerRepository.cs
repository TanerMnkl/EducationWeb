using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Abstract
{
    public interface ITrainerRepository:IGenericRepository<Trainer>
    {
        Task<bool> AnyAsync(int id);
       
        Task<List<Trainer>> GetAllTrainersAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Trainer trainer);
    }
}
