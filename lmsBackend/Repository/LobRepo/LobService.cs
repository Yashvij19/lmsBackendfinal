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

        public async Task<LobResponseDto?> EditLobAsync(int id, LobResponseDto createLobDto)
        {
            var existingLob = await _context.Lobs.FirstOrDefaultAsync(l => l.LobId == id);
            if (existingLob == null)
            {
                throw new InvalidOperationException($"LOB with ID {id} not found.");
            }

            // Update properties
            existingLob.LobName = createLobDto.LobName;
            existingLob.LobDescription = createLobDto.LobDescription;
            existingLob.Status = createLobDto.Status;

            await _context.SaveChangesAsync(); // Save changes

            return _mapper.Map<LobResponseDto>(existingLob);
        }

        public async Task<LobResponseDto?> UpdateLobAsync(int id, LobResponseDto updateLobDto)
        {
            var existingLob = await _context.Lobs.FindAsync(id);
            if (existingLob == null)
            {
                throw new InvalidOperationException($"LOB with ID {id} not found.");
            }

            // Update properties
            existingLob.LobName = updateLobDto.LobName ?? existingLob.LobName;
            existingLob.LobDescription = updateLobDto.LobDescription ?? existingLob.LobDescription;
            existingLob.Status = updateLobDto.Status;

            await _context.SaveChangesAsync(); // Save changes

            return _mapper.Map<LobResponseDto>(existingLob);
        }
    }
}
