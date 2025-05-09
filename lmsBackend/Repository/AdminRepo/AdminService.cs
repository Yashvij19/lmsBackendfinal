using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.AdminDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.AdminRepo
{
    public class AdminService:IAdmin
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AdminService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<AdminResponseDto>> GetAdminsAsync()
        {
            var admins = await _context.Admins
                .Include(a => a.User)
                .ToListAsync();
            return _mapper.Map<List<AdminResponseDto>>(admins);
        }
        public async Task<AdminResponseDto?> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == id);
            if (admin == null)
            {
                return null;
            }
            return _mapper.Map<AdminResponseDto>(admin);
        }
        public async Task<AdminResponseDto?> CreateAdminAsync(CreateAdminDto createAdminDto)
        {
            var user = await _context.Users.FindAsync(createAdminDto.UserId);
            if (user == null) return null;

            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.UserId == createAdminDto.UserId);
            if (existingAdmin != null) return null;

            user.RoleId = 2;
            _context.Entry(user).State = EntityState.Modified;

            var admin = _mapper.Map<Admin>(createAdminDto);
            _context.Admins.Add(admin);

            await _context.SaveChangesAsync();

            admin = await _context.Admins.Include(a => a.User).FirstOrDefaultAsync(a => a.AdminId == admin.AdminId);
            return admin == null ? null : _mapper.Map<AdminResponseDto>(admin);

        }
    }
}
