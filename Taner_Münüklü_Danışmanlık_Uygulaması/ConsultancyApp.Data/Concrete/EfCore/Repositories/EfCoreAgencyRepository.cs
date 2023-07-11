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
    public class EfCoreAgencyRepository : EfCoreGenericRepository<Agencies>, IAgenciesRepository
    {
        ConsultancyAppContext _context = new ConsultancyAppContext();
        public async Task CreateWithUrl(Agencies agencies)
        {
            await _context.Agencies.AddAsync(agencies);
            await _context.SaveChangesAsync();
            agencies.Url = agencies.Url + "-" + agencies.Id;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Agencies>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null)
        {
            var result = _context
                .Agencies
                .Where(a => a.IsDeleted == isDeleted)
                .AsQueryable();
            if (isActive!=null)
            {
                result = result
                    .Where(a => a.IsActive == isActive)
                    .AsQueryable();
                
            }
            return await result.ToListAsync();
        }
    }
}
