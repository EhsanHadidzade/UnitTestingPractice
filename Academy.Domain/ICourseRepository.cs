using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain
{
    public interface ICourseRepository
    {
        long create(Course course);
        List<Course> GetList();
        Course GetById(long id);
        void remove(long id);
        Course GetByName(string name);
    }
}
