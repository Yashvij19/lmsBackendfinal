using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(255)]
        public string RoleName { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; }
    }
}
