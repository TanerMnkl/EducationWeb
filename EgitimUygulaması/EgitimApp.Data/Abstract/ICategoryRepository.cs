using EgitimApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<bool> AnyAsync(int id);
        
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive = null);
    }
}
