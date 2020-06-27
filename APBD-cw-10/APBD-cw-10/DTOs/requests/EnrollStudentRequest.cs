using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.DTOs.requests
{
    public class EnrollStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }

        [Required(ErrorMessage = "Musisz podać imię")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Studies { get; set; }
    
}
}
