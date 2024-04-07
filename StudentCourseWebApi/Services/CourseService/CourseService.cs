using StudentCourseCore.Models;
using StudentCourseData.Dapper.CourseRepo;

namespace StudentCourseWebApi.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

       
        /// <summary>
        /// Get Course by Id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<Course> GetCourseById(int courseId)
        {
            var course = _courseRepository.GetCourseByIdAsync(courseId);
            return course;
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Course>> GetCourses()
        {
          var courses = await _courseRepository.GetAllCoursesAsync();
            return courses;
        }
        /// <summary>
        /// Add course 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<int> AddCourse(Course course)
        {
            var insertedCourseId = await _courseRepository.AddCourseAsync(course);
            return insertedCourseId;
        }
        /// <summary>
        /// Update course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public async Task<int> UpdateCourse(Course course)
        {
            var updatedCourseId = await _courseRepository.UpdateCourseAsync(course);
            return updatedCourseId;
        }
        /// <summary>
        /// Delete Course by courseId
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<int> DeleteCourseByIdAsync(int courseId)
        {
            var course = await _courseRepository.DeleteCourseByIdAsync(courseId);
            return course;
        }

        /// <summary>
        /// Add relation between student and course.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<int> AddStudentAndCourse(int studentId,int courseId)
        {
            var courses = await _courseRepository.AddStudentAndCourseAsync(studentId,courseId);
            return courses;
        }
    }
}
