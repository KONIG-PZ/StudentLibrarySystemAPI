using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentLibrarySystem.Data;
using StudentLibrarySystem.Models;
using StudentLibrarySystem.Models.Entities;

namespace StudentLibrarySystem.Controllers
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
            var studentEntity = new Students()
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                GradeLevel = addStudentDto.GradeLevel,
                Email = addStudentDto.Email,
                PhoneNumber = addStudentDto.PhoneNumber
            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);
        }

        //Get Id
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
                return StatusCode(500, "An error occurred");
            }
        }

        //Put
        [HttpPut("{id:guid}")]
        public IActionResult UpdateStudent(Guid id, UpdateStudentsDto updateStudentsDto)
        {
            var student = dbContext.Students.Find(id);
            if (student is null)
            {
                return NotFound();
            }
            student.FirstName = updateStudentsDto.FirstName;
            student.LastName = updateStudentsDto.LastName;
            student.GradeLevel = updateStudentsDto.GradeLevel;
            student.Email = updateStudentsDto.Email;
            student.PhoneNumber = updateStudentsDto.PhoneNumber;

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
