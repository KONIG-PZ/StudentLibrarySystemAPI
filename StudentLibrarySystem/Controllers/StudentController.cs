using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentLibrarySystem.Data;
using StudentLibrarySystem.Models;

namespace StudentLibrarySystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApiContext _context;

        //Context
        public StudentController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Students students)
        {
            if (students.Id == 0)
            {
                _context.StudentInfo.Add(students);
            }
            else
            {
                var accountsInDb = _context.StudentInfo.Find(students.Id);

                if (accountsInDb == null)
                    return new JsonResult(NotFound());
                accountsInDb = students;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(students));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int Id)
        {
            var result = _context.StudentInfo.Find(Id);

            if(result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        //Delete
        [HttpDelete]
        public JsonResult Delete(int Id)
            {
            var result = _context.StudentInfo.Find(Id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.StudentInfo.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());

            }
        //GetAll

        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.StudentInfo.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
