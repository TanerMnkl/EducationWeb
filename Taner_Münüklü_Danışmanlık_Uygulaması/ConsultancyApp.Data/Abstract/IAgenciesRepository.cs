using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public  interface IAgenciesRepository:IGenericRepository<Agencies>
    {
        Task<List<Agencies>> GetAllAuthorsAsync(bool isDeleted, bool? isActive = null);
        Task CreateWithUrl(Agencies agencies);

    }
}
