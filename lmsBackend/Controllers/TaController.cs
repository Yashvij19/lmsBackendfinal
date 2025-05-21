using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.TaDtos;
using lmsBackend.Models;
using lmsBackend.Repository.TaRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaController : ControllerBase
    {
        private readonly ITa _taService;

        public TaController(ITa taService)
        {
            _taService = taService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaResponseDtos>>> GetTas()
        {
            var tas = await _taService.GetTaAsync();
            return Ok(tas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaResponseDtos>> GetTa(int id)
        {
            var ta = await _taService.GetTaByIdAsync(id);
            if (ta == null) return NotFound();
            return Ok(ta);
        }

        [HttpPost]
        public async Task<ActionResult<TaResponseDtos>> CreateTa(CreateTaDtos createTaDto)
        {
            var ta = await _taService.CreateTaAsync(createTaDto);
            if (ta == null) return BadRequest("Invalid Admin ID.");
            return CreatedAtAction(nameof(GetTa), new { id = ta.TaId }, ta);
        }
    }
}