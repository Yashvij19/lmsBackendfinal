using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.AdminDtos
{
    public class CreateAdminDto
    {
        [Required]
        public int UserId { get; set; }
    }
}
