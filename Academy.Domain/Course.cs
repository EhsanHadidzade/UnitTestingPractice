using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academy.Domain
{
    public class Course
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string InstructorName { get; set; }
        public bool IsOnline { get; set; }
        public List<Section> Sections { get; set; }


        public Course(string name, string instructorName, bool isOnline)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(instructorName))
                throw new ArgumentNullException();

            if (!isOnline)
                throw new Exception();

            Name = name;
            InstructorName = instructorName;
            IsOnline = isOnline;
            Sections = new List<Section>();
        }

        //public Course(long id, string name, string instructorName, bool isOnline)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //        throw new ArgumentNullException();

        //    if (string.IsNullOrWhiteSpace(instructorName))
        //        throw new ArgumentNullException();

        //    if (!isOnline)
        //        throw new Exception();

        //    Id = id;
        //    Name = name;
        //    InstructorName = instructorName;
        //    IsOnline = isOnline;
        //    Sections = new List<Section>();
        //}

        public void Addsection(Section section)
        {
            this.Sections.Add(section);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Course course)
                return false;

            return course.Id == Id;
        }
    }
}
