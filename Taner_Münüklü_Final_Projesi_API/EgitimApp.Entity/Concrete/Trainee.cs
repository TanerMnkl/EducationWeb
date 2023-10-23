using EgitimApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Entity.Concrete
{
    public class Trainee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Education { get; set; }
        public string Url { get; set; }

    }
}
