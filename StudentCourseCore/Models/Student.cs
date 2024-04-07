using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseCore.Models
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }
        public string? DateOfBirth { get; set; }

        public char? Gender { get; set; }
    }
}
