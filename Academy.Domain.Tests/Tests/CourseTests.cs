using Academy.Domain.Tests.unit.Builders;
using Academy.Domain.Tests.unit.ClassFixture;
using Academy.Domain.Tests.unit.Factories;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Domain.Tests.unit.Tests
{
    public class CourseTests : IClassFixture<IdentifierFixture>
    {
        private readonly CourseTestBuilder courseBuilder;
        public CourseTests()
        {
            courseBuilder = new CourseTestBuilder();
        }

        [Fact]
        public void Constructor_ShouldConstructCourse()
        {
            //const int Id = 1;
            const string Name = "myCourse";
            const string InstructorName = "teacher";
            const bool IsOnline = true;
            var courseBuilder = new CourseTestBuilder();
            var course = courseBuilder.Build();

            //course.Id.Should().Be(Id);
            course.Name.Should().Be(Name);
            course.InstructorName.Should().Be(InstructorName);
            course.IsOnline.Should().Be(IsOnline);
            course.Sections.Should().BeEmpty();
            //Assert.Equal(Id, course.Id);
            //Assert.Equal(Name, course.Name);
            //Assert.Equal(InstructorName, course.InstructorName);
            //Assert.Equal(IsOnline, course.IsOnline);
        }

        [Fact]
        public void Constructor_ShouldThrowException_When_NameIsNull()
        {
            Action course = () => courseBuilder.WithName("").Build();

            course.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_ShouldThrowException_When_InstructorNameIsNull()
        {
            Action course = () => courseBuilder.WithInstructorName("").Build();

            course.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_ShouldThrowException_When_IsOnlineIsFalse()
        {
            Action course = () => courseBuilder.WithIsOnline(false).Build();
            course.Should().Throw<Exception>();
        }

        [Fact]
        public void AddSection_ShouldAddSectionToSections_WhenNameAndIdArePassed()
        {
            //Arrange
            var course = courseBuilder.Build();
            var section = SectionFactory.Create();

            //Act
            course.Addsection(section);

            //verify
            course.Sections.Should().ContainEquivalentOf(section);
        }

        [Fact]
        public void Equality_ShouldBeTrue_IfIdsAreEqual()
        {
            //Arrange
            var sameId = 1;
            var courseBiulder = new CourseTestBuilder();
            var course1 = courseBiulder.Build();
            course1.Id = sameId;
            var course2 = courseBiulder.Build();
            course2.Id = sameId;

            //act
            var actual =course1.Equals(course2);

            //assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Equality_ShouldBeFalse_IfIdsAreNotEqual()
        {
            //Arrange
            var courseBiulder = new CourseTestBuilder();
            var course1 = courseBiulder.Build();
            course1.Id = 1;
            var course2 = courseBiulder.Build();
            course2.Id = 2;

            //act
            var actual = course1.Equals(course2);

            //assert
            actual.Should().BeFalse();
        }

        [Fact]
        public void Equality_ShouldBeFalse_IfObjectIsNull()
        {
            //Arrange
            var courseBiulder = new CourseTestBuilder();
            var course1 = courseBiulder.Build();

            //act
            var actual = course1.Equals(null);

            //assert
            actual.Should().BeFalse();
        }
    }
}
