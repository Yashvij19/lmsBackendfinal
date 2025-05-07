using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.LobDtos;
using lmsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LobsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LobsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Lobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LobResponseDto>>> GetLobs()
        {
            var lobs = await _context.Lobs.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<LobResponseDto>>(lobs));
        }

        // GET: api/Lobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LobResponseDto>> GetLob(int id)
        {
            var lob = await _context.Lobs.FindAsync(id);

            if (lob == null)
            {
                return NotFound();
            }

            return _mapper.Map<LobResponseDto>(lob);
        }

        // POST: api/Lobs
        [HttpPost]
        public async Task<ActionResult<LobResponseDto>> CreateLob(CreateLobDto createLobDto)
        {
            var lob = _mapper.Map<Lob>(createLobDto);
            _context.Lobs.Add(lob);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLob), new { id = lob.LobId }, _mapper.Map<LobResponseDto>(lob));
        }
    }
}
