using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using APBD_cw_10.DTOs.requests;
using APBD_cw_10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw_10.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IDbService _service;

        public EnrollmentController(IDbService service) 
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> EnrollStudent(EnrollStudentRequest request)
        {
            return await _service.EnrollStudent(request);
        }

        [HttpPost("promote")]

        public async Task<IActionResult> PromoteStudents(PromoteStudentRequest request) 
        {
            return await _service.PromoteStudents(request);
        }

    }
}
