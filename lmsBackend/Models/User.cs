using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata;

namespace lmsBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

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
        [StringLength(255)]
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
        public DateTime ExpectanceDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(200)]
        public string CollegeTier { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        public bool Status { get; set; } = true;

        public bool IsSuperAdmin { get; set; } = false;

        [Required]
        [StringLength(200)]
        public string JoinerStatus { get; set; } = string.Empty;

        [Required]
        public int Revokes { get; set; } = 0;

        [Required]
        [StringLength(255)]
        public string Uploader { get; set; } = string.Empty;

        [Required]
        public int IsTerm { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int RoleId { get; set; } = 1; // Default role is user (1)

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("LobId")]
        public virtual Lob Lob { get; set; }
    }
}
