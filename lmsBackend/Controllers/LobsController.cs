using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.LobDtos;
using lmsBackend.Models;
using lmsBackend.Repository.LobRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LobsController : ControllerBase
    {
        private readonly ILob _lobService;

        public LobsController(ILob lobService)
        {
            _lobService = lobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LobResponseDto>>> GetLobs()
        {
            var lobs = await _lobService.GetLobsAsync();
            return Ok(lobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LobResponseDto>> GetLob(int id)
        {
            var lob = await _lobService.GetLobByIdAsync(id);
            if (lob == null) return NotFound();
            return Ok(lob);
        }

        [HttpPost]
        public async Task<ActionResult<LobResponseDto>> CreateLob(CreateLobDto createLobDto)
        {
            var lob = await _lobService.CreateLobAsync(createLobDto);
            return CreatedAtAction(nameof(GetLob), new { id = lob?.LobId }, lob);
        }
    }

}
