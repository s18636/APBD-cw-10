using APBD_cw_10.DTOs.requests;
using APBD_cw_10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.Services
{
    interface IDbService
    {
        Task<IActionResult> GetStudents();
        Task<IActionResult> ModifyStudent(ModifyStudentRequest request);
        
        Task<IActionResult> RemoveStudent(RemoveStudentRequest request);
        Task<IActionResult> PromoteStudents(PromoteStudentsRequest request);
        Task<IActionResult> EnrollStudent(EnrollStudentRequest request);



    }
}
