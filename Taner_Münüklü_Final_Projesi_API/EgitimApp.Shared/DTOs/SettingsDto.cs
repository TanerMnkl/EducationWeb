using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Shared.DTOs
{
    public class SettingsDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string About { get; set; }
        public int Contact { get; set; }
        public string QuestionAsked { get; set; }
    }
}
