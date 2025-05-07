using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Lob
    {
        [Key]
        public int LobId { get; set; }

        [Required]
        [StringLength(255)]
        public string LobName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string LobDescription { get; set; } = string.Empty;

        [Required]
        public bool Status { get; set; } = true;

        public virtual ICollection<User> Users { get; set; }
    }
}
