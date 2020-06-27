using APBD_cw_10.DTOs.requests;
using APBD_cw_10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw_10.Services
{
    public class SqlServerDbService : IDbService
    {

        private readonly s18636Context _context;

        public SqlServerDbService(s18636Context context) 
        {
            _context = context;
        }

        public async Task<IActionResult> GetStudents()
        {
            return new OkObjectResult(_context.Student.ToList());
        }

        public async Task<IActionResult> ModifyStudent(ModifyStudentRequest request)
        {
            var student = _context.Student.FirstOrDefault(n => n.IndexNumber == request.IndexNumber);
            if (student == null)
            {
                return new BadRequestResult();
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.BirthDate = request.BirthDate;
            student.IdEnrollment = request.IdEnrollment;

            await _context.SaveChangesAsync();
            return new OkObjectResult(student);
        }

        public async Task<IActionResult> RemoveStudent(string IndexNumber)
        {
            var student = _context.Student.FirstOrDefault(n => n.IndexNumber == IndexNumber);
            if (student == null) 
            {
                return new BadRequestResult();
            }

            _context.Remove(student);
            await _context.SaveChangesAsync();
            return new OkObjectResult(student);
        }

        public async Task<IActionResult> PromoteStudents(PromoteStudentRequest request)
        {
            throw new NotImplementedException();
        }


        public Task<IActionResult> EnrollStudent(EnrollStudentRequest request)
        {
            throw new NotImplementedException();
        }


        

        

        
    }
}
