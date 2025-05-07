using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public long? Phone { get; set; }

        [Required]
        public int LobId { get; set; }

       

        [Required]
        [StringLength(255)]
        public string Designation { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Level { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string SubLob { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string CollegeName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string CollegeLocation { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string OfferReleaseSpoc { get; set; } = string.Empty;

        [Required]
        public DateTime Doj { get; set; }

        [Required]
        [StringLength(200)]
        public string Trf { get; set; } = string.Empty;

        [Required]
        public DateTime ExpectanceDate { get; set; }

        [Required]
        [StringLength(200)]
        public string CollegeTier { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string JoinerStatus { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Uploader { get; set; } = string.Empty;

    }
}
