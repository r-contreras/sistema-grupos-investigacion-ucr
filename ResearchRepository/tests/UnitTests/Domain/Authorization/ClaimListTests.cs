using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ResearchRepository.Domain.Authorization;

namespace UnitTests.Domain.Authorization
{
    public class ClaimListTests
    {
        [Fact]
        public void TestConstructor()
        {
            //arrange
            ClaimsList p = new ClaimsList();
            //act
            var list = p.Claims;
            //assert
            list.Should().NotBeEmpty();
            list.Count.Should().Be(10);
        }
        
    }
}
