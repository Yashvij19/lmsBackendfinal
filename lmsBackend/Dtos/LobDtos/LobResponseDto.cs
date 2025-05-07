namespace lmsBackend.Dtos.LobDtos
{
    public class LobResponseDto
    {
        public int LobId { get; set; }
        public string LobName { get; set; } = string.Empty;
        public string LobDescription { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
