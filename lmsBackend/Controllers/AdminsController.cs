using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.AdminDtos;
using lmsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdminsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminResponseDto>>> GetAdmins()
        {
            var admins = await _context.Admins
                .Include(a => a.User)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AdminResponseDto>>(admins));
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminResponseDto>> GetAdmin(int id)
        {
            var admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == id);

            if (admin == null)
            {
                return NotFound();
            }

            return _mapper.Map<AdminResponseDto>(admin);
        }

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<AdminResponseDto>> CreateAdmin(CreateAdminDto createAdminDto)
        {
            var user = await _context.Users.FindAsync(createAdminDto.UserId);
            if (user == null)
            {
                return BadRequest("Invalid User ID.");
            }

            // Check if user is already an admin
            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.UserId == createAdminDto.UserId);
            if (existingAdmin != null)
            {
                return BadRequest("User is already an admin.");
            }

            // Update user role to Admin (RoleId = 2)
            user.RoleId = 2;
            _context.Entry(user).State = EntityState.Modified;

            var admin = _mapper.Map<Admin>(createAdminDto);
            _context.Admins.Add(admin);

            await _context.SaveChangesAsync();

            // Reload admin with user information
            admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == admin.AdminId);

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminId }, _mapper.Map<AdminResponseDto>(admin));
        }
    }
}
