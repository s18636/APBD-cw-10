using APBD_cw_10.DTOs.requests;
using APBD_cw_10.DTOs.Responses;
using APBD_cw_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var enrollment = _context.Enrollment.Join(_context.Studies, e => e.IdStudy, s => s.IdStudy, (e, s) => new {
                enrolIdStud = e.IdStudy,
                studIdStud = s.IdStudy,
                s.Name,
                e.Semester
                    }).FirstOrDefault(a => a.enrolIdStud == a.studIdStud &&
                                      a.Name == request.StudiesName &&
                                      a.Semester == request.Semester);

            if (enrollment == null)
            {
                return new BadRequestResult();
            }

            try
            {
               _context.Database.ExecuteSqlRaw($"PromoteStudents {request.Semester},{request.StudiesName}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return new BadRequestResult();
            }

            return new OkObjectResult(new PromoteStudentResponse
            {
                Studies = request.StudiesName,
                Semester = request.Semester
            });
        }


        public async Task<IActionResult> EnrollStudent(EnrollStudentRequest request)
        {
            var IdStudy = _context.Studies.Where(s => s.Name == request.Studies)
                .Select(s => s.IdStudy ).FirstOrDefault();

            var enrollment = _context.Enrollment.FirstOrDefault(e => e.IdStudy == IdStudy && e.Semester == 1);

            int enrollId;
            if (enrollment == null)
            {
                enrollId = _context.Enrollment.Max(enr => enr.IdEnrollment) + 1;
                _context.Enrollment.Add(new Enrollment()
                {
                    IdEnrollment = enrollId,
                    Semester = 1,
                    IdStudy = IdStudy,
                    StartDate = DateTime.Now
                });
            }
            else
                enrollId = enrollment.IdEnrollment;


            var newStudent = _context.Student.FirstOrDefault(st => st.IndexNumber == request.IndexNumber);

            if (newStudent == null) return new BadRequestResult();

          
            _context.Student.Add(new Student()
            {
                IdEnrollment = enrollId,
                BirthDate = request.Birthdate,
                FirstName = request.FirstName,
                LastName = request.LastName
            });

            await _context.SaveChangesAsync();
            return new OkObjectResult(new EnrollStudentResponse()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Birthdate = request.Birthdate,
                IndexNumber = request.IndexNumber,
                Semester = 1,
                Studies = request.Studies
            });
        }


        

        

        
    }
}
