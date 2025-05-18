using lmsBackend.Dtos.CategoriesDtos;
using lmsBackend.Models;

namespace lmsBackend.Repository.CategoriesRepo
{
    public interface Icategories
    {
        Task<IEnumerable<CategoriesResponseDtos>> GetAllCategories();
        Task<CategoriesResponseDtos> GetCategoriesById(int id);
        Task AddCategories(CreatCategoriesDtos category);
        Task UpdateCategories(int id, CreatCategoriesDtos categoryDto);

    }
}
