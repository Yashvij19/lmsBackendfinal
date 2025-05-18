using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Module
    {
        [Required]
        [Key]
        public int module_id { get; set; }

        [Required]
        public int course_id { get; set; }

        [ForeignKey("course_id")]
        public Courses Course { get; set; }

        [Required]
        [StringLength(255)]
        public string modulename { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        [Required]
        public int duration { get; set; }

        [Required]
        public string videopath { get; set; } = string.Empty;

        [Required]
        public string documentpath { get; set; } = string.Empty;

        [Required]
        public string supdocumentpath { get; set; } = string.Empty;

        [Required]
        public bool status { get; set; } = true;

        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
    }
}
