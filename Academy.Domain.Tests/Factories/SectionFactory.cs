using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Tests.unit.Factories
{
    public class SectionFactory
    {
        public static Section Create()
        {
            return new Section(2, "BDD");
        }
    }
}
