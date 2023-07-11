using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Contexts;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        ConsultancyAppContext _context = new ConsultancyAppContext();
        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive = null)
        {
            var result = _context
                .Categories
                .Where(c => c.IsDeleted == isDeleted)
                .AsQueryable();

            if (isActive!=null)
            {
                result = result
                    .Where(c => c.IsActive == isActive)
                    .AsQueryable();
                
            }
            return await result.ToListAsync();
        }
    }
}
