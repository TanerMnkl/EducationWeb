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
    public class EfCoreTrainerRepository : EfCoreGenericRepository<Trainer>, ITrainerRepository
    {
        public EfCoreTrainerRepository(EducationAppContext _context) : base(_context)
        {

        }
        private EducationAppContext Context
        {
            get { return _dbContext as EducationAppContext; }
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await Context
                .Trainers
                .AnyAsync(t=>t.Id == id);
        }

        public async Task CreateWithUrl(Trainer trainer)
        {
            await Context.Trainers.AddAsync(trainer);
            await Context.SaveChangesAsync();
            trainer.Url = trainer.Url + "-" + trainer.Id;
            await Context.SaveChangesAsync();   
        }

        public async Task<List<Trainer>> GetAllTrainersAsync(bool isDeleted, bool? isActive = null)
        {
            var result = Context
                .Trainers
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
