using Academy.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Academy.Infrastructure.Tests.Integration
{
    public class RealDatabaseFixture : IDisposable
    {
        public AcademyContext Context { get; set; }
        private readonly TransactionScope _scope;
        public RealDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<AcademyContext>()
             .UseSqlServer("Server=.;Database=TDD-Academy;Trusted_Connection=True;")
             .Options;
            Context = new AcademyContext(options);
            _scope = new TransactionScope();

            var obj1 = new Course("obj1", "Instractor1", true);
            var obj2 = new Course("obj2", "Instractor2", true);
            var obj3 = new Course("obj3", "Instractor3", true);
            Context.Add(obj1);
            Context.Add(obj2);
            Context.Add(obj3);
            Context.SaveChanges();
        }
        public void Dispose()
        {
            _scope.Dispose();
            Context.Database.ExecuteSqlRaw("truncate table [TDD-Academy].[dbo].[Courses]");
            Context.SaveChanges();

            Context.Dispose();
        }
    }
}
