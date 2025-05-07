namespace lmsBackend.Dtos.AdminDtos
{
    public class AdminResponseDto
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long? Phone { get; set; }
        public string SmeId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
