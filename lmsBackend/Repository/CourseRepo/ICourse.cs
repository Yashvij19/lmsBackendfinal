using lmsBackend.Dtos.CourseDtos;
using lmsBackend.Models;

namespace lmsBackend.Repository.CourseRepo
{
    public interface ICourse
    {
        Task<IEnumerable<ResponseCourseDtos>> GetAllAsync();
        Task<ResponseCourseDtos?> GetByIdAsync(int id);
        Task AddAsync(CreateCourseDto courseDto);
        Task UpdateAsync(CreateCourseDto courseDto, int id);
    }
}
