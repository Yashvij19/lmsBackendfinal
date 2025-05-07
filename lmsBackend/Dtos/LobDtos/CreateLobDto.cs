using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.LobDtos
{
    public class CreateLobDto
    {
        [Required]
        [StringLength(255)]
        public string LobName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string LobDescription { get; set; } = string.Empty;
    }
}
