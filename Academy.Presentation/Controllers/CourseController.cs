using Academy.Application.Course;
using Academy.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Academy.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public List<Course> GetList()
        {
            return _courseService.GetAll();
        }

        [HttpPost]
        public long Create(CreateCourse command)
        {
            var id = _courseService.create(command);
            return id;

        }

        [HttpPut]
        public long Edit(EditCourse command)
        {
           return  _courseService.Edit(command);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _courseService.Delete(id);
        }
    }
}
