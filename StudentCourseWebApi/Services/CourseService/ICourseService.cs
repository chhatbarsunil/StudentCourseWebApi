using StudentCourseCore.Models;

namespace StudentCourseWebApi.Services.CourseService
{
    public interface ICourseService
    {
        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Course>> GetCourses();

        /// <summary>
        /// Get course by id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<Course> GetCourseById(int courseId);

        /// <summary>
        /// Add course 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Task<int> AddCourse(Course course);

        /// <summary>
        /// Update Course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public Task<int> UpdateCourse(Course course);

        /// <summary>
        /// Delete Course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<int> DeleteCourseByIdAsync(int courseId);
        
        /// <summary>
        /// Add Relationship between of student and course
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<int> AddStudentAndCourse(int studentId, int courseId);

    }
    
}
