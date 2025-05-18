using AutoMapper;
using lmsBackend.DataAccessLayer;
using lmsBackend.Dtos.ModuleDtos;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lmsBackend.Repository.ModuleRepo
{
    public class ModuleService : IModule
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ModuleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseModuleDtos>> GetAllAsync()
        {
            var modules = await _context.Modules.Include(m => m.Course).ToListAsync();
            return _mapper.Map<IEnumerable<ResponseModuleDtos>>(modules);
        }

        public async Task<ResponseModuleDtos?> GetByIdAsync(int id)
        {
            var module = await _context.Modules.Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.module_id == id);

            return _mapper.Map<ResponseModuleDtos>(module);
        }

        public async Task AddAsync(CreateModuleDtos moduleDto)
        {
            string videoPath = SaveFile(moduleDto.VideoFile, "VideoUpload");
            string pdfPath = SaveFile(moduleDto.PdfFile, "PdfUpload");

            var module = new Module
            {
                modulename = moduleDto.modulename,
                description = moduleDto.description,
                duration = moduleDto.duration,
                course_id = moduleDto.course_id,
                videopath = videoPath,
                documentpath = pdfPath,
                createdat = DateTime.UtcNow,
                updatedat = DateTime.UtcNow
            };

            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateModuleDtos moduleDto)
        {
            var existingModule = await _context.Modules.FindAsync(id);
            if (existingModule == null) return;

            // Handle file updates
            if (moduleDto.VideoFile != null)
            {
                DeleteFile(existingModule.videopath);
                existingModule.videopath = SaveFile(moduleDto.VideoFile, "VideoUpload");
            }

            if (moduleDto.PdfFile != null)
            {
                DeleteFile(existingModule.documentpath);
                existingModule.documentpath = SaveFile(moduleDto.PdfFile, "PdfUpload");
            }

            // Update non-file fields
            existingModule.modulename = moduleDto.modulename;
            existingModule.description = moduleDto.description;
            existingModule.duration = moduleDto.duration;
            existingModule.updatedat = DateTime.UtcNow;

            _context.Modules.Update(existingModule);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteAsync(int id)
        //{
        //    var module = await _context.Modules.FindAsync(id);
        //    if (module == null) return;

        //    DeleteFile(module.videopath);
        //    DeleteFile(module.documentpath);

        //    _context.Modules.Remove(module);
        //    await _context.SaveChangesAsync();
        //}

        private string SaveFile(IFormFile file, string folderName)
        {
            if (file == null) return string.Empty;

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folderName}");
            Directory.CreateDirectory(uploadFolder);
            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/{folderName}/{fileName}";
        }

        private void DeleteFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + filePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
    }
}