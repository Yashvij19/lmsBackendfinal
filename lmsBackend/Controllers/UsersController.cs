using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.User;
using lmsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<UserResponseDto>>(users));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserResponseDto>(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto createUserDto)
        {
            // Check if the LOB exists
            var lob = await _context.Lobs.FindAsync(createUserDto.LobId);
            if (lob == null)
            {
                return BadRequest("Invalid LOB ID.");
            }

            var user = _mapper.Map<User>(createUserDto);

            // Convert LOB ID to string for the User entity
            user.LobId = createUserDto.LobId;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Reload user with related entities
            user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Lob)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, _mapper.Map<UserResponseDto>(user));
        }
    }
}
