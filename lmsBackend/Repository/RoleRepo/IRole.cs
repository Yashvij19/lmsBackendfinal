using lmsBackend.Dtos.RoleDtos;

namespace lmsBackend.Repository.RoleRepo
{
    public interface IRole
    {
        Task<IEnumerable<RoleResponseDto>> GetRolesAsync();
        Task<RoleResponseDto?> GetRoleByIdAsync(int id);
        Task<RoleResponseDto?> CreateRoleAsync(CreateRoleDto createRoleDto);
    }
}
