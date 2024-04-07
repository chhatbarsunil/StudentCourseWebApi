using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseCore.Models;
using StudentCourseWebApi.Services.CourseService;

namespace StudentCourseWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        [HttpGet("courses")]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            IEnumerable<Course> courses = await _courseService.GetCourses();
            return courses;
        }
        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<Course>> GetCourseById(int courseId)
        {
            Course course = await _courseService.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound();
            }

            return course;

        }
        [HttpPost("addcourse")]
        public async Task<ActionResult> AddCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.AddCourse(course);
                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while adding the course."); // Internal Server Error (500)
            }
        }

        [HttpPut("/course/{courseId}")]
        public async Task<IActionResult> UpdateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.UpdateCourse(course);
                return NoContent(); // No Content (204) on successful update
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }


        [HttpDelete("/course/{courseId}")]
        public async Task<IActionResult> DeleteCourseById(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.DeleteCourseByIdAsync(courseId);
                return NoContent(); // No Content (204) on successful deletion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
        [HttpPost("addstudentandcourserelation")]
        public async Task<ActionResult> AddStudentAndCourse([FromBody] StudendAndCourseRelationRequest studendAndCourseRelationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.AddStudentAndCourse(studendAndCourseRelationRequest.StudentId, studendAndCourseRelationRequest.CourseId);
                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Log the exception for debugging
                return StatusCode(500, "An error occurred while udpating the relation between student and course."); // Internal Server Error (500)
            }
        }
    }
}
