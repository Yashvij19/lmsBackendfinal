using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string SmeId { get; set; } = string.Empty;

        public string TaId { get; set; } = string.Empty;

        [Required]
        public bool Status { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
