using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Courses
    {
        [Key]
        [Required]
        public int course_id { get; set; }

        [Required]
        public string course_name { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        [Required]
        public string imagepath { get; set; } = string.Empty;

        [Required]
        public string assignment { get; set; } = string.Empty;

        [Required]
        public string sme_id { get; set; } = string.Empty;

        [Required]
        public string lob_id { get; set; } = string.Empty;

        [Required]
        public int category_id { get; set; }

        [ForeignKey("category_id")]
        public Categories Category { get; set; }


        [Required]
        public int isquiz { get; set; } = 0;

        [Required]
        public string quizpath { get; set; } = string.Empty;

        [Required]
        public string author { get; set; } = string.Empty;

        [Required]
        public string uploader { get; set; } = string.Empty;

        [Required]
        public bool status { get; set; } = true;

        [Required]
        public int duration { get; set; }

        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }

        //Relationship : one course has many modules

        public ICollection<Module> Modules { get; set; }
    }
}
