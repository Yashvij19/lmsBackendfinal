namespace lmsBackend.Dtos.CourseDtos
{
    public class ResponseCourseDtos
    {
        public int course_id { get; set; }
        public string course_name { get; set; } = string.Empty;
        public string imagepath { get; set; } = string.Empty;
        public bool status { get; set; } = true;
    }
}

