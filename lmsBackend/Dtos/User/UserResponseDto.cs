namespace lmsBackend.Dtos.User
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long? Phone { get; set; }
        public int LobId { get; set; }
        public string LobName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string SubLob { get; set; } = string.Empty;
        public string CollegeName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string CollegeLocation { get; set; } = string.Empty;
        public string OfferReleaseSpoc { get; set; } = string.Empty;
        public DateTime Doj { get; set; }
        public string Trf { get; set; } = string.Empty;
        public DateTime ExpectanceDate { get; set; }
        public string CollegeTier { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string JoinerStatus { get; set; } = string.Empty;
        public int Revokes { get; set; }
        public string Uploader { get; set; } = string.Empty;
        public int IsTerm { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
