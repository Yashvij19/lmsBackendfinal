using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.TaDtos
{
    public class CreateTaDtos
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //[Required]
        //[StringLength(255)]
        //public string Password { get; set; } = string.Empty;

        [Required]
        public long? Phone { get; set; }
    }
}
