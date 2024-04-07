using AutoMapper.Configuration;
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

namespace StudentCourseData.Dapper.StudentRepo
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("StudentCourseDefault")??"";
        }
       

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Student>("SELECT * FROM Student");
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            using var connection = new SqlConnection(_connectionString);
            Student student = await connection.QueryFirstOrDefaultAsync<Student>("SELECT * FROM Student WHERE StudentId = @StudentId", new { StudentId = studentId }) ?? new Student();
            return student;
        }
        public async Task<int> AddStudentAsync(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("StudentName", student.StudentName);
            parameters.Add("DateOfBirth", student.DateOfBirth);
            parameters.Add("Gender", student.Gender);

            // Use stored procedure or parameterized query for security
            var addedStudentId = await connection.ExecuteAsync("SP_InsertStudent", parameters, commandType: CommandType.StoredProcedure);
            return addedStudentId;
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("StudentId", student.StudentId);
            parameters.Add("StudentName", student.StudentName);
            parameters.Add("DateOfBirth", student.DateOfBirth);
            parameters.Add("Gender", student.Gender);

            // Use stored procedure or parameterized query for security
            var updatedStudentId = await connection.ExecuteAsync("SP_UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
            return updatedStudentId;
        }
        public async Task<int> DeleteStudentByIdAsync(int studentId)
        {
            using var connection = new SqlConnection(_connectionString);
            var deletedStudentId = await connection.ExecuteAsync("DELETE FROM Student WHERE StudentId = @StudentId", new { StudentId = studentId });
            return deletedStudentId;
        }
    }
}
