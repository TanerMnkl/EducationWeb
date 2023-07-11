using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int HowManyOfExperince { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string  About { get; set; }


    }
}
