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
    public class lobsController : ControllerBase
    {
        private readonly ILob _lobService;

        public lobsController(ILob lobService)
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
        public async Task<ActionResult<LobResponseDto>> CreateLob([FromBody] CreateLobDto createLobDto)
        {
            var lob = await _lobService.CreateLobAsync(createLobDto);
            return CreatedAtAction(nameof(GetLob), new { id = lob?.LobId }, lob);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LobResponseDto>> EditLob(int id, [FromBody] LobResponseDto createLobDto)
        {
            var lob = await _lobService.UpdateLobAsync(id, createLobDto);
            if (lob == null) return NotFound();
            return Ok(lob);
        }
    }

}
