namespace lmsBackend.Dtos.TaDtos
{
    public class TaResponseDtos
    {
        public int TaId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long? Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
