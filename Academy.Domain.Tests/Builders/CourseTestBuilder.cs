namespace Academy.Domain.Tests.unit.Builders
{
    public class CourseTestBuilder
    {
        int Id = 0;
        string Name = "myCourse";
        string InstructorName = "teacher";
        bool IsOnline = true;


        //public CourseTestBuilder WithId(int id)
        //{
        //    this.Id = id;
        //    return this;

        //}
        public CourseTestBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public CourseTestBuilder WithInstructorName(string instructorName)
        {
            InstructorName = instructorName;
            return this;
        }

        public CourseTestBuilder WithIsOnline(bool isOnline)
        {
            IsOnline = isOnline;
            return this;
        }

        public Course Build()
        {
            return new Course(Name,InstructorName, IsOnline);
        }
    }
}
