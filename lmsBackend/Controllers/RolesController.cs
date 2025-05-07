using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.RoleDtos;
using lmsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RolesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<RoleResponseDto>>(roles));
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponseDto>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return _mapper.Map<RoleResponseDto>(role);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<RoleResponseDto>> CreateRole(CreateRoleDto createRoleDto)
        {
            var role = _mapper.Map<Role>(createRoleDto);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, _mapper.Map<RoleResponseDto>(role));
        }
    }
}
