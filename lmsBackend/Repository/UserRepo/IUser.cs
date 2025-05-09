using lmsBackend.Dtos.User;

namespace lmsBackend.Repository.UserRepo
{
    public interface IUser
    {
        Task<List<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task<UserResponseDto?> CreateUserAsync(CreateUserDto createUserDto);
    }
}
