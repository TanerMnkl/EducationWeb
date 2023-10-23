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
    public class EfCoreTraineeRepository : EfCoreGenericRepository<Trainee>, ITraineeRepository
    {
        public EfCoreTraineeRepository(EducationAppContext dbContext) : base(dbContext)
        {
        }
        private EducationAppContext Context
        {
            get { return _dbContext as EducationAppContext; }
        }
        public async Task<bool> AnyAsync(int id)
        {

            return await Context
                .Trainees
                .AnyAsync(x => x.Id == id);
        }

        public async Task<List<Trainee>> GetAllTraineesAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
             .Trainees
             .Where(c => c.IsDeleted == isDeleted)
             .AsQueryable();
            if (isActive != null)
            {
                result = result
                    .Where(c => c.IsActive == isActive)
                    .AsQueryable();

            }
            return await result.ToListAsync();
        }
    }
}
