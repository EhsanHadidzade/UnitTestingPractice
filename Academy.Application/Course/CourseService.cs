using Academy.Application.Tests.unit;
using Academy.Domain;
using System;
using System.Collections.Generic;

namespace Academy.Application.Course
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public long create(CreateCourse command)
        {
            if (_courseRepository.GetByName(command.Name) != null)
                throw new Exception();

            var course = new Academy.Domain.Course(command.Name, command.InstructorName, command.IsOnline);
            _courseRepository.create(course);
            return course.Id;
                
        }

        public void Delete(int id)
        {
            _courseRepository.remove(id);
        }

        public long Edit(EditCourse command)
        {
           var mycourse=_courseRepository.GetById(command.Id);
            if (mycourse == null)
                throw new Exception();

            _courseRepository.remove(command.Id);
            var course=new Academy.Domain.Course(command.Name,command.InstructorName,command.IsOnline);
            _courseRepository.create(course);
            return course.Id;
        }

        public List<Domain.Course> GetAll()
        {
            return _courseRepository.GetList();
        }

        //public Domain.Course GetById(int id)
        //{
        //   throw new NotImplementedException();
        //}
    }
}