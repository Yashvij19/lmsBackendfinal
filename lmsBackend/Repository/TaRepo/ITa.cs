using lmsBackend.Dtos.SmeDtos;
using lmsBackend.Dtos.TaDtos;

namespace lmsBackend.Repository.TaRepo
{
    public interface ITa
    {
        Task<IEnumerable<TaResponseDtos>> GetTaAsync();
        Task<TaResponseDtos?> GetTaByIdAsync(int id);
        Task<TaResponseDtos?> CreateTaAsync(CreateTaDtos createTaDto);
    }
}
