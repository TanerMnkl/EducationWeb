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
    public class EfCoreSettingsRepository : EfCoreGenericRepository<Settings>, ISettingsRepository
    {
        public EfCoreSettingsRepository(EducationAppContext _context) : base(_context)
        {

        }
        private EducationAppContext Context
        {
            get { return _dbContext as EducationAppContext; }
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context.Settings.AnyAsync(s=>s.Id == id);
        }
    }
}
