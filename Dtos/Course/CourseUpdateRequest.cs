namespace NhuThuan_K2023_THIGK.Dtos.Course
{
    public class CourseUpdateRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}
