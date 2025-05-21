using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.TaDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.TaRepo
{
    public class TaService : ITa
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaResponseDtos>> GetTaAsync()
        {
            var tas = await _context.Tas.Include(t => t.Admin).ToListAsync();
            return _mapper.Map<IEnumerable<TaResponseDtos>>(tas);
        }

        public async Task<TaResponseDtos?> GetTaByIdAsync(int id)
        {
            var ta = await _context.Tas.Include(t => t.Admin).FirstOrDefaultAsync(t => t.TaId == id);
            return ta == null ? null : _mapper.Map<TaResponseDtos>(ta);
        }

        public async Task<TaResponseDtos?> CreateTaAsync(CreateTaDtos createTaDto)
        {
            var admin = await _context.Admins.Include(a => a.User).FirstOrDefaultAsync(a => a.User.Email == createTaDto.Email && a.User.Phone == createTaDto.Phone);
            if (admin == null) return null;

            var ta = _mapper.Map<Ta>(createTaDto);
            ta.AdminId = admin.AdminId;
            ta.Password = "evs@123";
            _context.Tas.Add(ta);

            string taIdValue = $"TA{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            admin.TaId = taIdValue;
            _context.Entry(admin).State = EntityState.Modified;

            admin.User.RoleId = 4;
            _context.Entry(admin.User).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            ta = await _context.Tas.Include(t => t.Admin).FirstOrDefaultAsync(t => t.TaId == ta.TaId);
            return ta == null ? null : _mapper.Map<TaResponseDtos>(ta);
        }
    }
}