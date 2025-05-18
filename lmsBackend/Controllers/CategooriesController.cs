using AutoMapper;
using lmsBackend.Dtos.CategoriesDtos;
using lmsBackend.Models;
using lmsBackend.Repository.CategoriesRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Icategories _repository;
        private readonly IMapper _mapper;
        public CategoriesController(Icategories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var data = await _repository.GetAllCategories();
        //    var mappedData = _mapper.Map<IEnumerable<CategoriesResponseDtos>>(data);

        //    return Ok(new { categories = mappedData });
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _repository.GetAllCategories();

                var response = new
                {
                    success = true,
                    message = "Categories fetched successfully",
                    data = data
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");

                var errorResponse = new
                {
                    success = false,
                    message = "An error occurred while fetching categories",
                    error = ex.Message
                };

                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetCategoriesById(id);
            if (data == null) return NotFound();
            return Ok(_mapper.Map<CategoriesResponseDtos>(data));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreatCategoriesDtos categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Category data is missing");

            await _repository.AddCategories(categoryDto);
            return Ok(new { message = "Category added successfully" });
        }
       

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreatCategoriesDtos categoryDto)
        {
            try
            {
                await _repository.UpdateCategories(id, categoryDto);
                return Ok(new { message = "Category updated successfully."});
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
