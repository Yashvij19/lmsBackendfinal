using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.CategoriesDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.CategoriesRepo
{
    public class CategoriesService:Icategories
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriesResponseDtos>> GetAllCategories()
        {
            var categories = await _context.Categories.Include(c => c.Courses).ToListAsync();
            return _mapper.Map<IEnumerable<CategoriesResponseDtos>>(categories);
        }

        public async Task<CategoriesResponseDtos> GetCategoriesById(int id)
        {
            var category = await _context.Categories.Include(c => c.Courses).FirstOrDefaultAsync(c => c.id == id);
            return _mapper.Map<CategoriesResponseDtos>(category);
        }

        //public async Task AddCategories(CreatCategoriesDtos categoryDto)
        //{
        //    var category = _mapper.Map<Categories>(categoryDto);
        //    _context.Categories.Add(category);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task AddCategories(CreatCategoriesDtos categoryDto)
        //{
        //    string imagePath = null;

        //    if (categoryDto.ImageFile != null)
        //    {
        //        // Define folder path
        //        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploadimage");

        //        // Create folder if it doesn't exist
        //        if (!Directory.Exists(uploadFolder))
        //        {
        //            Directory.CreateDirectory(uploadFolder);
        //        }

        //        // Generate unique filename
        //        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryDto.ImageFile.FileName);
        //        string filePath = Path.Combine(uploadFolder, uniqueFileName);

        //        // Save file to server
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await categoryDto.ImageFile.CopyToAsync(stream);
        //        }

        //        // Set file path (relative or absolute)
        //        imagePath = $"/uploadimage/{uniqueFileName}";
        //    }

        //    // Map DTO to Entity
        //    var category = _mapper.Map<Categories>(categoryDto);
        //    category.imagepath = imagePath; // Save the file path in DB

        //    _context.Categories.Add(category);
        //    await _context.SaveChangesAsync();
        //}

        public async Task AddCategories(CreatCategoriesDtos categoryDto)
        {
            string imagePath = null;

            if (categoryDto.ImageFile != null)
            {
                // Define folder path inside wwwroot
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploadimage");

                // Create folder if it doesn't exist
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Generate unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryDto.ImageFile.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                // Save file to server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryDto.ImageFile.CopyToAsync(stream);
                }

                // Set full URL for frontend use
                imagePath = $"https://localhost:7264/uploadimage/{uniqueFileName}";
            }

            // Map DTO to Entity
            var category = _mapper.Map<Categories>(categoryDto);
            category.imagepath = imagePath; // ✅ Save the full URL in DB

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        //public async Task UpdateCategories(int id, CreatCategoriesDtos categoryDto)
        //{
        //    var existingCategory = await _context.Categories.FindAsync(id);

        //    if (existingCategory == null)
        //    {
        //        throw new KeyNotFoundException($"Category with ID {id} not found.");
        //    }

        //    // Update properties using AutoMapper
        //    _mapper.Map(categoryDto, existingCategory);

        //    // If ImageFile is provided, update the stored image
        //    if (categoryDto.ImageFile != null)
        //    {
        //        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploadimage");

        //        if (!Directory.Exists(uploadFolder))
        //        {
        //            Directory.CreateDirectory(uploadFolder);
        //        }

        //        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryDto.ImageFile.FileName);
        //        string filePath = Path.Combine(uploadFolder, uniqueFileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await categoryDto.ImageFile.CopyToAsync(stream);
        //        }

        //        existingCategory.imagepath = $"/uploadimage/{uniqueFileName}";
        //    }

        //    _context.Categories.Update(existingCategory);
        //    await _context.SaveChangesAsync();
        //}


        public async Task UpdateCategories(int id, CreatCategoriesDtos categoryDto)
        {
            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }


            
            _mapper.Map(categoryDto, existingCategory);

            
            if (categoryDto.ImageFile != null)
            {
              
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploadimage");

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(categoryDto.ImageFile.FileName);
                string filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryDto.ImageFile.CopyToAsync(stream);
                }

                // FIXED: Save full URL in DB just like in AddCategories method
                existingCategory.imagepath = $"https://localhost:7264/uploadimage/{uniqueFileName}";
            }

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
        }

    }
}
