using Academy.Application.Course;
using Academy.Presentation.Controllers;
using System;
using NSubstitute;
using Xunit;
using FluentAssertions;
using Academy.Domain;
using System.Collections.Generic;

namespace Academy.Presentation.Tests.Unit
{
    public class CourseControllerTests
    {
        private readonly CourseController controller;
        private readonly ICourseService _courseServices;
        public CourseControllerTests()
        {
            _courseServices = Substitute.For<ICourseService>();
            controller = new CourseController(_courseServices);
        }

        [Fact]
        public void Should_ReturnAllCourses()
        {
            //arrange

            //act
            controller.GetList();

            //assert
            _courseServices.Received().GetAll();
        }
        //OR
        [Fact]
        public void Should_ReturnListOfCourses()
        {
            //arrange
            _courseServices.GetAll().Returns(new List<Course>());

            //act
            var courses = controller.GetList();

            //assert
            courses.Should().BeOfType<List<Course>>();
        }

        [Fact]
        public void Should_CreateNewCourse()
        {
            //arrange
            var command = new CreateCourse()
            {
                Name = "Test",
                InstructorName = "TeacherTest",
                IsOnline = true,
            };

            //act
            controller.Create(command);

            //assert
            _courseServices.Received().create(command);
        }

        [Fact]
        public void Should_EditCourse()
        {
            //arrange
            var command = new EditCourse()
            {
                Id = 1,
                Name = "Test",
                InstructorName = "TeacherTest",
                IsOnline = true,
            };

            //act
            controller.Edit(command);

            //assert
            _courseServices.Received().Edit(command);
        }

        [Fact]
        public void Should_DeleteCourseById()
        {
            //arrange
            const int id = 1;

            //act
            controller.Delete(id);

            //assert
            _courseServices.Received().Delete(id);
        }
    }
}
