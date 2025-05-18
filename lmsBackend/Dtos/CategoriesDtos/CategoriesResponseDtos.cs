using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.CategoriesDtos
{
    public class CategoriesResponseDtos
    {

        public string name { get; set; } = string.Empty;

        public string imagepath { get; set; } = string.Empty;

        public string subset { get; set; } = string.Empty;

        public bool status { get; set; } = true;
    }
}
