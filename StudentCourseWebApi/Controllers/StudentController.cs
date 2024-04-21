using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseCore.Models;
using StudentCourseData.Dapper.StudentRepo;
using StudentCourseWebApi.Services.StudentService;

namespace StudentCourseWebApi.Controllers
{
    [Route("api/")]
    [Authorize]
    [ApiController]
    public class StudentController : ControllerBase
    {
        
       
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("students")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            IEnumerable<Student> students = await _studentService.GetStudents();
            return students;
        }
        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<Student>> GetStudentById(int studentId)
        {
            Student student  = await _studentService.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }

            return student;
            
        }

        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost("addstudent")]
        public async Task<ActionResult> AddStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studentService.AddStudent(student);
                return Ok();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while adding the student."); // Internal Server Error (500)
            }
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("/student/{studentId}")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studentService.UpdateStudent(student);
                return NoContent(); // No Content (204) on successful update
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        /// <summary>
        /// Delete studen by id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpDelete("/student/{studentId}")]
        public async Task<IActionResult> DeleteStudentById(int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studentService.DeleteStudentById(studentId);
                return NoContent(); // No Content (204) on successful deletion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
    }
}
