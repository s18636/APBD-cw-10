using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.DTOs.requests
{
    public class PromoteStudentRequest
    {
        [Required] 
        public string StudiesName { get; set; }
        [Required] 
        public int Semester { get; set; }
    }
}
