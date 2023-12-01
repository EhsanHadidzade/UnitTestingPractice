using Academy.Domain;
using Academy.Domain.Tests.unit.Builders;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Academy.Infrastructure.Tests.Integration
{
    public class CourseRepositoryTests : IClassFixture<RealDatabaseFixture>
    {
        private readonly courseRepository _courseRepository;
        private readonly CourseTestBuilder _builder;
        public CourseRepositoryTests(RealDatabaseFixture databaseFixture)
        {
            _courseRepository = new courseRepository(databaseFixture.Context);
            _builder = new CourseTestBuilder();
        }

        [Fact]
        public void Should_ReturnAllCourses()
        {
            //arrange

            //act
            var courses = _courseRepository.GetList();

            //assert
            courses.Should().HaveCountGreaterThanOrEqualTo(3);

        }

        [Fact]
        public void Should_CreateNewCourse()
        {
            //arrange
            var course = _builder.Build();

            //act
            _courseRepository.create(course);

            //assert
            var courses = _courseRepository.GetList();
            courses.Should().Contain(course);
        }

        [Fact]
        public void Should_ReturnCourseId_WhenCourseCreated()
        {
            //arrange
            var course = _builder.Build();

            //act
            var courseId = _courseRepository.create(course);

            //assert
            courseId.Should().Be(course.Id);
        }

        [Fact]
        public void Should_ReturnCourseById()
        {
            //arrange
            var course = _builder.Build();
            var courseId = _courseRepository.create(course);

            //act
            var actual = _courseRepository.GetById(courseId);

            //assert
            actual.Should().Be(course);
        }

        [Fact]
        public void Should_GetCourseByName()
        {
            //arrange
            const string name = "MyNamee";
            var course = _builder.WithName(name).Build();
            var courseId = _courseRepository.create(course);

            //act
            var actual = _courseRepository.GetByName(name);

            //assert
            actual.Should().Be(course);

        }


        [Fact]
        public void Should_RemoveCourseById()
        {
            //arrange
            var course = _builder.Build();
            var courseId = _courseRepository.create(course);

            //act
            _courseRepository.remove(courseId);

            //assert
            var actual = _courseRepository.GetById(courseId);
            actual.Should().BeNull();

        }
    }
}
