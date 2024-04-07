using StudentCourseCore.Models;

namespace StudentCourseWebApi.Services.StudentService
{
    public interface IStudentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Student>> GetStudents();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Student> GetStudentById(int id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Task<int> AddStudent(Student student);

        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Task<int> UpdateStudent(Student student);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Task<int> DeleteStudentById(int courseId);
       
    }
}
