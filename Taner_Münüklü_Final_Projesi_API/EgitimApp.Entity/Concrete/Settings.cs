using EgitimApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Entity.Concrete
{
    public class Settings:BaseEntity
    {
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string About { get; set; }
        public int Contact { get; set; }
        public string QuestionAsked { get; set; }

    }
}
