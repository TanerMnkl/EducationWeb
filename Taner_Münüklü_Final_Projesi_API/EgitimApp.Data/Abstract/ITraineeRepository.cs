using EgitimApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Abstract
{
    public interface ITraineeRepository:IGenericRepository<Trainee>
    {
        Task<List<Trainee>> GetAllTraineesAsync(bool isDeleted, bool? isActive = null);
        Task<bool> AnyAsync(int id);
    }
}
