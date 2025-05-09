using lmsBackend.Dtos.SmeDtos;

namespace lmsBackend.Repository.SmeRepo
{
    public interface ISme
    {
        Task<IEnumerable<SmeResponseDto>> GetSmesAsync();
        Task<SmeResponseDto?> GetSmeByIdAsync(int id);
        Task<SmeResponseDto?> CreateSmeAsync(CreateSmeDto createSmeDto);
    }
}
