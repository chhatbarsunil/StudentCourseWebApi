using Microsoft.AspNetCore.Mvc;
using StudentCourseCore.Models;
using StudentCourseData.Dapper.StudentRepo;
using StudentCourseWebApi.Services.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseWebApi.Services.StudentService
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Constructor of StudentService that injects StudentRepository
        /// </summary>
        /// <param name="studentRepository"></param>
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Get all students.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return students;
        }
        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(int id)
        {
            var students = await _studentRepository.GetStudentByIdAsync(id);
            return students;
        }
       

        /// <summary>
        /// Add the student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> AddStudent(Student student)
        {
            int insertedStudentId = await _studentRepository.AddStudentAsync(student);
            return insertedStudentId;
        }
        
        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<int> UpdateStudent(Student student)
        {
            int insertedStudentId = await _studentRepository.UpdateStudentAsync(student);
            return insertedStudentId;
        }

        /// <summary>
        /// Delete student by studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<int> DeleteStudentById(int studentId)
        {
            var deletedStudentId = await _studentRepository.DeleteStudentByIdAsync(studentId);
            return deletedStudentId;
        }
    }


}
