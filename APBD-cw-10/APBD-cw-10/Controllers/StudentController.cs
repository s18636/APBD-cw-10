using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_cw_10.DTOs.requests;
using APBD_cw_10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw_10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IDbService _service;

        public StudentController(IDbService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return await _service.GetStudents();
        }

        [HttpPut("modify")]
        public async Task<IActionResult> ModifyStudent(ModifyStudentRequest request)
        {
            return await _service.ModifyStudent(request);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveStudent(string IndexNumber)
        {
            return await _service.RemoveStudent(IndexNumber);
        }

    }

    

}
