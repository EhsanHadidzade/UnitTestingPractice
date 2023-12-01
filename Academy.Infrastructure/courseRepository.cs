using Academy.Application.Course;
using Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Infrastructure
{
    public class courseRepository : ICourseRepository
    {
        private readonly AcademyContext _context;

        public courseRepository(AcademyContext context)
        {
            _context = context;
        }

        public long create(Course course)
        {
           _context.Courses.Add(course);
            _context.SaveChanges();
            return course.Id;
        }

        public Course GetById(long id)
        {
            return _context.Courses.Find(id);
        }

        public Course GetByName(string name)
        {
            return _context.Courses.FirstOrDefault(c => c.Name == name);
        }

        public List<Course> GetList()
        {
            return _context.Courses.ToList();
        }

        public void remove(long id)
        {
            var course= _context.Courses.Find(id);
            _context.Remove(course);
            _context.SaveChanges();
        }
    }
}