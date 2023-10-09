﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Shared.DTOs
{
    public class TraineeCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Education { get; set; }
        public string Url { get; set; }
        public int[] Courses { get; set; }
    }
}
