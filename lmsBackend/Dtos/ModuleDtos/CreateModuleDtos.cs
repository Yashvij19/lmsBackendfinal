namespace lmsBackend.Dtos.ModuleDtos
{
    public class CreateModuleDtos
    {
        public string modulename { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public int duration { get; set; }
        public int course_id { get; set; }

        public IFormFile VideoFile { get; set; } // Accepts video uploads
        public IFormFile PdfFile { get; set; }   // Accepts PDF uploads
    }
}
