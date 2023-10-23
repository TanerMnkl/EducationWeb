using EgitimApp.Data.Abstract;
using EgitimApp.Data.Concrete.EfCore.Contexts;
using EgitimApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(EducationAppContext _context) : base(_context)
        {

        }
        private EducationAppContext Context
        {
            get { return _dbContext as EducationAppContext; }
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context
                .Categories
                .AnyAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
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
