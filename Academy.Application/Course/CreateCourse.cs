namespace Academy.Application.Course
{
    public class CreateCourse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string InstructorName { get; set; }
        public bool IsOnline { get; set; }
    }
}