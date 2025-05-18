using System.ComponentModel.DataAnnotations;

namespace lmsBackend.Dtos.ModuleDtos
{
    public class ResponseModuleDtos
    {
        public string modulename { get; set; } = string.Empty;
        public int module_id { get; set; }

        public string description { get; set; } = string.Empty;

        public int duration { get; set; }
    }
}
