using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Tests.unit.ClassFixture
{
    public class IdentifierFixture : IDisposable
    {
        public static Guid Id { set; get; }

        public IdentifierFixture()
        {
            Id = Guid.NewGuid();
        }
        public void Dispose()
        {
        }
    }
}
