using Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Course
{
    public interface ICourseService
    {
        long create(CreateCourse command);
        long Edit(EditCourse command);
        List<Academy.Domain.Course> GetAll();
        void Delete(int id);
        //Domain.Course GetById(int id);
    }
}
