using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.SmeDtos;
using lmsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SmesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Smes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmeResponseDto>>> GetSmes()
        {
            var smes = await _context.Smes
                .Include(s => s.Admin)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<SmeResponseDto>>(smes));
        }

        // GET: api/Smes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmeResponseDto>> GetSme(int id)
        {
            var sme = await _context.Smes
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(s => s.SmeId == id);

            if (sme == null)
            {
                return NotFound();
            }

            return _mapper.Map<SmeResponseDto>(sme);
        }

        // POST: api/Smes
        [HttpPost]
        public async Task<ActionResult<SmeResponseDto>> CreateSme(CreateSmeDto createSmeDto)
        {
            // Check if the admin exists
            var admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AdminId == createSmeDto.AdminId);

            if (admin == null)
            {
                return BadRequest("Invalid Admin ID.");
            }

            // Create new SME
            var sme = _mapper.Map<Sme>(createSmeDto);
            _context.Smes.Add(sme);

            // Generate a unique SME ID for the admin
            string smeIdValue = $"SME{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            admin.SmeId = smeIdValue;
            _context.Entry(admin).State = EntityState.Modified;

            // Update user role to SME (RoleId = 3)
            admin.User.RoleId = 3;
            _context.Entry(admin.User).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            sme = await _context.Smes
                .Include(s => s.Admin)
                .FirstOrDefaultAsync(s => s.SmeId == sme.SmeId);

            return CreatedAtAction(nameof(GetSme), new { id = sme.SmeId }, _mapper.Map<SmeResponseDto>(sme));
        }
    }
}
