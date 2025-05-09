using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.LobDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.LobRepo
{
    public class LobService:ILob
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LobService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LobResponseDto>> GetLobsAsync()
        {
            var lobs = await _context.Lobs.ToListAsync();
            return _mapper.Map<IEnumerable<LobResponseDto>>(lobs);
        }

        public async Task<LobResponseDto?> GetLobByIdAsync(int id)
        {
            var lob = await _context.Lobs.FindAsync(id);
            return lob == null ? null : _mapper.Map<LobResponseDto>(lob);
        }

        public async Task<LobResponseDto?> CreateLobAsync(CreateLobDto createLobDto)
        {
            var lob = _mapper.Map<Lob>(createLobDto);
            _context.Lobs.Add(lob);
            await _context.SaveChangesAsync();
            return _mapper.Map<LobResponseDto>(lob);
        }

    }
}
