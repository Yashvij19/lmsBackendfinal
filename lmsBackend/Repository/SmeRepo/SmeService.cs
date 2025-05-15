using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.SmeDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.SmeRepo
{
    public class SmeService:ISme
    {
        
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SmeResponseDto>> GetSmesAsync()
        {
            var smes = await _context.Smes.Include(s => s.Admin).ToListAsync();
            return _mapper.Map<IEnumerable<SmeResponseDto>>(smes);
        }

        public async Task<SmeResponseDto?> GetSmeByIdAsync(int id)
        {
            var sme = await _context.Smes.Include(s => s.Admin).FirstOrDefaultAsync(s => s.SmeId == id);
            return sme == null ? null : _mapper.Map<SmeResponseDto>(sme);
        }

        public async Task<SmeResponseDto?> CreateSmeAsync(CreateSmeDto createSmeDto)
        {
            var admin = await _context.Admins.Include(a => a.User).FirstOrDefaultAsync(a => a.User.Email == createSmeDto.Email && a.User.Phone == createSmeDto.Phone);
            if (admin == null) return null;

            var sme = _mapper.Map<Sme>(createSmeDto);
            sme.AdminId = admin.AdminId;
            sme.Password = "evs@123";
            _context.Smes.Add(sme);

            string smeIdValue = $"SME{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            admin.SmeId = smeIdValue;
            _context.Entry(admin).State = EntityState.Modified;

            admin.User.RoleId = 3;
            _context.Entry(admin.User).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            sme = await _context.Smes.Include(s => s.Admin).FirstOrDefaultAsync(s => s.SmeId == sme.SmeId);
            return sme == null ? null : _mapper.Map<SmeResponseDto>(sme);
        }
    }
}

