using lmsBackend.Dtos.LobDtos;

namespace lmsBackend.Repository.LobRepo
{
    public interface ILob
    {
        Task<IEnumerable<LobResponseDto>> GetLobsAsync();
        Task<LobResponseDto?> GetLobByIdAsync(int id);
        Task<LobResponseDto?> CreateLobAsync(CreateLobDto createLobDto);
        Task<LobResponseDto?> EditLobAsync(int id, LobResponseDto createLobDto);

        Task<LobResponseDto?> UpdateLobAsync(int id, LobResponseDto createLobDto);
    }
}
