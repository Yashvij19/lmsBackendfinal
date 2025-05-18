using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Categories
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; } = string.Empty;

        [Required]
        public string imagepath { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string subset { get; set; } = string.Empty;

        [Required]
        public bool status { get; set; } = true;

        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }

        // Relationship : one category has many courses 
       public ICollection<Courses> Courses { get; set; }
    }
}
