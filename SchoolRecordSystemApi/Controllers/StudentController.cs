using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolRecordSystemApi.Data;
using SchoolRecordSystemApi.Models;
using SchoolRecordSystemApi.Models.Entities;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace SchoolRecordSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public StudentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get All
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var allStudent = await dbContext.Students.ToListAsync();
            return Ok(allStudent);
        }

        //Post 
        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var studentEntity = new Student()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                Section = addStudentDto.Section,
                GradeLevel = addStudentDto.GradeLevel,
                Subject = addStudentDto.Subject,
                Email = addStudentDto.Email,
                PhoneNumber = addStudentDto.PhoneNumber
            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        // Get Id
        [HttpGet("{id:guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            try
            {
                var student = dbContext.Students.Find(id);

                if (student is null)
                {
                    return NotFound("Student Not Found");
                }
                return Ok(student);
            }
            catch(Exception ex)
            {

                return StatusCode(500, "An Error Occured");
            }
        }

        //Put
        [HttpPut("{id:guid}")]
        public IActionResult UpdateStudent (Guid id, UpdateStudentDto updateStudentDto)
        {
            var student = dbContext.Students.Find(id);

            if(student is null)
            {
                return NotFound();
            }
            student.FirstName = updateStudentDto.FirstName;
            student.LastName = updateStudentDto.LastName;
            student.Section = updateStudentDto.Section;
            student.GradeLevel = updateStudentDto.GradeLevel;
            student.Subject = updateStudentDto.Subject;
            student.Email = updateStudentDto.Email;
            student.PhoneNumber = updateStudentDto.PhoneNumber;

            dbContext.SaveChanges();

            return Ok(student);
        }

        //Delete
        [HttpDelete ("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = dbContext.Students.Find(id);

            if(student is null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();

            return Ok();
        }
            
    }
}
