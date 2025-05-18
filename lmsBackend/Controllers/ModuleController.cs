using AutoMapper;
using lmsBackend.Dtos.ModuleDtos;
using lmsBackend.Models;
using lmsBackend.Repository.ModuleRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace lmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModule _repository;
        private readonly IMapper _mapper;

        public ModuleController(IModule repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modules = await _repository.GetAllAsync();
            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var module = await _repository.GetByIdAsync(id);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateModuleDtos moduleDto)
        {
            await _repository.AddAsync(moduleDto);
            return Ok("Module added successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateModuleDtos moduleDto)
        {
            await _repository.UpdateAsync(id, moduleDto);
            return Ok("Module updated successfully");
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _repository.DeleteAsync(id);
        //    return Ok("Module deleted successfully");
        //}
    }
}