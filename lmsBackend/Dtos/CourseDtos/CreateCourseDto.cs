using System.ComponentModel.DataAnnotations;
using lmsBackend.Models;

namespace lmsBackend.Dtos.CourseDtos
{
    public class CreateCourseDto
    {
        public string course_name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public IFormFile imagepath { get; set; } 

        public string sme_id { get; set; } = string.Empty;

        public string lob_id { get; set; } = string.Empty;

        public int category_id { get; set; }  // Changed from Category to category_id

        public string author { get; set; } = string.Empty;

        public IFormFile quizPath { get; set; }
    }
}
