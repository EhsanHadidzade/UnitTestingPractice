using Academy.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrastructure
{
    public class AcademyContext:DbContext
    {
        public DbSet<Course> Courses{ get; set; }
        public AcademyContext(DbContextOptions<AcademyContext> options):base(options)
        {

        }
    }
}
