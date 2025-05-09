using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.User;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.UserRepo
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDto>> GetUsersAsync()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .ToListAsync();

            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .FirstOrDefaultAsync(u => u.Id == id);

            return user == null ? null : _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> CreateUserAsync(CreateUserDto createUserDto)
        {
            var lob = await _context.Lobs.FindAsync(createUserDto.LobId);
            if (lob == null) return null;

            var user = _mapper.Map<User>(createUserDto);
            user.LobId = createUserDto.LobId;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            return user == null ? null : _mapper.Map<UserResponseDto>(user);
        }
    }
}
