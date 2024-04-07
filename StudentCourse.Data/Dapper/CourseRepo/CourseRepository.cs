using Dapper;
using Microsoft.Extensions.Configuration;
using StudentCourseCore.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseData.Dapper.CourseRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public CourseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("StudentCourseDefault") ?? "";

        }
      

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            var parameters = new DynamicParameters();
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.QueryAsync<Course>("SELECT * FROM Course");
            return result;
            
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            using var connection = new SqlConnection(_connectionString);
            Course course = await connection.QueryFirstOrDefaultAsync<Course>("SELECT * FROM Course WHERE CourseId = @CourseId", new { CourseId = courseId }) ?? new Course();
            return course;
        }
        public async Task<int> AddCourseAsync(Course course)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("CourseName", course.CourseName);

            // Use stored procedure or parameterized query for security
            var insertedCourseId = await connection.ExecuteAsync("SP_InsertCourse", parameters, commandType: CommandType.StoredProcedure);
            return insertedCourseId;

        }

        public async Task<int> UpdateCourseAsync(Course course)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("CourseId", course.CourseId);
            parameters.Add("CourseName", course.CourseName);

            // Use stored procedure or parameterized query for security
            var insertedCourseId = await connection.ExecuteAsync("SP_UpdateCourse", parameters, commandType: CommandType.StoredProcedure);
            return insertedCourseId;

        }
        public async Task<int> DeleteCourseByIdAsync(int courseId)
        {
            using var connection = new SqlConnection(_connectionString);
            var course = await connection.ExecuteAsync("DELETE FROM Course WHERE CourseId = @CourseId", new { CourseId = courseId });
            return course;
        }
        public async Task<int> AddStudentAndCourseAsync(int studentId,int courseId)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("StudentId", studentId);
            parameters.Add("CourseId", courseId);

            // Use stored procedure or parameterized query for security
            var insertedId = await connection.ExecuteAsync("SP_InsertStudentCourse", parameters, commandType: CommandType.StoredProcedure);
            return insertedId;
        }

    }
}
