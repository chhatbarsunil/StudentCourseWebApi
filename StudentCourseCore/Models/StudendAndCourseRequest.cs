using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseCore.Models
{
    public class StudendAndCourseRelationRequest
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
