using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using RESTFulSense.Clients;
using System.Collections.Generic;
using Academy.Domain;
using FluentAssertions;
using Academy.Application.Course;

namespace Academy.Presentation.Tests.Integration
{
    public class CourseControllerTests
    {
        private const string path = "/api/Course";
        private readonly RESTFulApiFactoryClient _restClient;
        public CourseControllerTests()
        {
            var _applicationFactory = new WebApplicationFactory<Startup>();
            var httpClient = _applicationFactory.CreateClient();
            _restClient = new RESTFulApiFactoryClient(httpClient);
        }

        [Fact]
        public async void Should_GetAllCourses()
        {
            //arrange
            //var applicationFactory = new WebApplicationFactory<Startup>();
            //var httpClient = applicationFactory.CreateClient();
            //var restClient = new RESTFulApiFactoryClient(httpClient);

            //act
            var actual = await _restClient.GetContentAsync<List<Course>>(path);


            //assert
            actual.Should().HaveCountGreaterThanOrEqualTo(0);

        }

        [Fact]
        public async void Should_CreateNewCourse()
        {
            //arrange
            var command = new CreateCourse()
            {
                Name = "aspNet",
                InstructorName = "bb",
                IsOnline = true,
            };

            //act
            var id = await _restClient.PostContentAsync<CreateCourse, long>(path, command);
            var courses = await _restClient.GetContentAsync<List<Course>>(path);

            //assert
            courses.Should().ContainSingle(x => x.Id == id);

            //tearDown
            await _restClient.DeleteContentAsync($"{path}/{id}");
        }

        [Fact]
        public async void Should_EditExistingCourse()
        {
            //arrange
            var createCourse = new CreateCourse()
            {
                Name = "bbb",
                InstructorName = "bb",
                IsOnline = true,
            };
            long id = await _restClient.PostContentAsync<CreateCourse, long>(path, createCourse);
            var editCourse = new EditCourse()
            {
                Id = id,
                Name = "NEWbbb",
                InstructorName = "bb",
                IsOnline = true,
            };

            //act
            var newId = await _restClient.PutContentAsync<object>(path, editCourse);

            //assert
            var courses= await _restClient.GetContentAsync<List<Course>>(path);
            courses.Should().ContainSingle(x => x.Id == Convert.ToInt64(newId));
            courses.Should().NotContain(x=>x.Id==id);
        }

        [Fact]
        public async void Should_RemoveCourseById()
        {
            //arrange
            var createCourse = new CreateCourse()
            {
                Name = "bbb",
                InstructorName = "bb",
                IsOnline = true,
            };
            long id = await _restClient.PostContentAsync<CreateCourse, long>(path, createCourse);

            //act
            await _restClient.DeleteContentAsync($"{path}/{id}");

            //assert
            var courses = await _restClient.GetContentAsync<List<Course>>(path);
            courses.Should().NotContain(x=>x.Id== id);
        }





    }
}
