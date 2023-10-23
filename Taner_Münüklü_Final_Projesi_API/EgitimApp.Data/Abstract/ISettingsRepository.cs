using EgitimApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Abstract
{
    public interface ISettingsRepository:IGenericRepository<Settings>
    {
        Task<bool> AnyAsync(int id);
    }
}
