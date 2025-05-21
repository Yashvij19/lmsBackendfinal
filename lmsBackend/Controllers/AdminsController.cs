using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.AdminDtos;
using lmsBackend.Models;
using lmsBackend.Repository.AdminRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class adminsController : ControllerBase
    {
        private readonly IAdmin _adminService;

        public adminsController(IAdmin adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminResponseDto>>> GetAdmins()
        {
            var admins = await _adminService.GetAdminsAsync();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminResponseDto>> GetAdmin(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<AdminResponseDto>> CreateAdmin(CreateAdminDto createAdminDto)
        {
            var admin = await _adminService.CreateAdminAsync(createAdminDto);
            if (admin == null) return BadRequest("Invalid User ID or User is already an admin.");
            return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminId }, admin);
        }
    }
}
