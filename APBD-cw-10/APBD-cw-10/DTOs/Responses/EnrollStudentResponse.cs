﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.DTOs.Responses
{
    public class EnrollStudentResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int Semester { get; set; }
        public string Studies { get; set; }
    }
}
