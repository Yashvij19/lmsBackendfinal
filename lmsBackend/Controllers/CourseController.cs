using AutoMapper;
using lmsBackend.Dtos.CourseDtos;
using lmsBackend.Models;
using lmsBackend.Repository.CourseRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _repository;
        private readonly IMapper _mapper;


        public CourseController(ICourse repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coursesDto = await _repository.GetAllAsync();
            return Ok(coursesDto); // Ensure only the DTOs are being returned
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courseDto = await _repository.GetByIdAsync(id);
            if (courseDto == null) return NotFound();
            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCourseDto courseDto)
        {
            var value= await _repository.AddAsync(courseDto);
            var response = new { success = true,
                data =value ,
                message = "Course added successfully"
                };
            return Ok(response); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateCourseDto courseDto)
        {
            await _repository.UpdateAsync(courseDto, id);
            return Ok("Course updated");
        }
    }
}
