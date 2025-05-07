using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.RoleDtos
{
    public class CreateRoleDto
    {
        [Required]
        [StringLength(255)]
        public string RoleName { get; set; } = string.Empty;
    }
}
