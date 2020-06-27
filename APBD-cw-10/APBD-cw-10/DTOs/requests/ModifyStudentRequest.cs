using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.DTOs.requests
{
    public class ModifyStudentRequest
    {
        [Required] 
        public string IndexNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required] 
        public int IdEnrollment { get; set; }
    }
}
