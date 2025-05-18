using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.CategoriesDtos
{
    public class CreatCategoriesDtos
    {
        public string name { get; set; } = string.Empty;

        public IFormFile ImageFile { get; set; }

        public string subset { get; set; } = string.Empty;
    }
}
