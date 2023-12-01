using Academy.Application.Course;
using Academy.Domain;
using Academy.Domain.Tests.unit.Builders;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Academy.Application.Tests.unit
{
    public class CourseServiceTests
    {
        private readonly CourseTestBuilder _builder;
        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;
        public CourseServiceTests()
        {
            _builder = new CourseTestBuilder();
            _courseRepository = Substitute.For<ICourseRepository>();
            _courseService = new CourseService(_courseRepository);
        }

        [Fact]
        public void Create_ShouldCreateANewCourse()
        {
            //Arrange
            var command = new CreateCourse()
            {
                Id = 1,
                Name = "MicroService",
                InstructorName = "MR.Yasin",
                IsOnline = true
            };
            //var courseRepository = Substitute.For<ICourseRepository>();
            //var courseServive = new CourseService(_courseRepository);

            //Act
            long id = _courseService.create(command);

            //Assert
            _courseRepository.Received(1).create(Arg.Any<Academy.Domain.Course>());

        }

        [Fact]
        public void Create_ShouldReturnCourseId_WhenCourseCreated()
        {
            //Arrange
            var command = new CreateCourse()
            {
                Name = "MicroService",
                InstructorName = "MR.Yasin",
                IsOnline = true
            };
            _courseRepository.create(default).ReturnsForAnyArgs(10);
         

            //Act

            var actual = _courseService.create(command);

            //Assert
            actual.Should().Be(command.Id);

        }

        [Fact]
        public void Create_ShouldReturnDuplicatedException_WhenCourseNameIsExisted()
        {
            //Arrange
            var command = new CreateCourse()
            {
                Name = "MicroService",
                InstructorName = "MR.Yasin",
                IsOnline = true
            };
            //var courseRepository = Substitute.For<ICourseRepository>();
            var course = _builder.Build();
            _courseRepository.GetByName(Arg.Any<string>()).Returns(course);
            //var courseServive = new CourseService(courseRepository);

            //Act

            Action actual = () => _courseService.create(command);

            //Assert
            actual.Should().Throw<Exception>();
        }

        [Fact]
        public void Edit_ShouldThrowExeption_WhenCourseIsNullForEdit()
        {
            //Arrange
            var command = new EditCourse()
            {
                Name = "Asp",
                InstructorName = "Ehsan",
                IsOnline = true
            };
            _courseRepository.GetById(command.Id).ReturnsNull();

            //Act
           Action action=()=> _courseService.Edit(command);

            //verify
            action.Should().Throw<Exception>();

        }

        [Fact]
        public void Edit_ShouldUpdateCourse()
        {
            //Arrange
            var command = new EditCourse()
            {
                Name = "Asp",
                InstructorName = "Ehsan",
                IsOnline = true
            };
            var course = _builder.Build();
            _courseRepository.GetById(command.Id).Returns(course);

            //Act
            _courseService.Edit(command);

            //Assert
            Received.InOrder(() =>
            {
                _courseRepository.remove(command.Id);
                _courseRepository.create(Arg.Any<Academy.Domain.Course>());
            });
        }
        [Fact]
        public void SHould_ReturnIdOfUpdatedCourse()
        {
            //Arrange
            var command = new EditCourse()
            {
                Name = "Asp",
                InstructorName = "Ehsan",
                IsOnline = true
            };
            _courseRepository.create(default).ReturnsForAnyArgs(10);
            var course = _builder.Build();
            var updatedCourse = _courseRepository.GetById(command.Id).Returns(course);

            //Act

            var actual = _courseService.Edit(command);

            //Assert
            actual.Should().Be(command.Id);
        }

        [Fact]
        public void GetAll_ShouldReturnAllCourses()
        {
            //Arrange
            _courseRepository.GetList().Returns(new System.Collections.Generic.List<Domain.Course>());

            //Act
            var courses = _courseService.GetAll();

            //Assert
            courses.Should().BeOfType<List<Domain.Course>>();
        }


        [Fact]
        public void Delete_ShouldDeleteCourse_WhenCourseIdIsPassed()
        {
            //Arrange
            const int id = 4;

            //Act
            _courseService.Delete(4);

            //Assert
            _courseRepository.Received().remove(id);

        }




    }
}
