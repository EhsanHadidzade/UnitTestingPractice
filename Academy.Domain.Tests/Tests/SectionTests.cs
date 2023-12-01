using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Academy.Domain.Tests.unit.Tests
{
    public class SectionTests
    {
        [Fact]
        public void Constructor_ShouldConstructSection_Properly()
        {
            //Arrange
            const int id = 1;
            const string name = "Tdd";


            //Act
            var section = new Section(id, name);


            //Verify
            section.Id.Should().Be(id);
            section.Name.Should().Be(name);
        }

    }
}
