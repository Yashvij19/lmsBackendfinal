using lmsBackend.Dtos.AdminDtos;

namespace lmsBackend.Repository.AdminRepo
{
    public interface IAdmin
    {
        Task<List<AdminResponseDto>> GetAdminsAsync();
        Task<AdminResponseDto?> GetAdminByIdAsync(int id);
        Task<AdminResponseDto?> CreateAdminAsync(CreateAdminDto createAdminDto);
    }
}
