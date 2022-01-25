using FluentAssertions;
using ResearchRepository.Domain.StatisticsContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.StatisticsContext
{
    public class PublicationTests
    {

        [Fact]
        public void checkStatisticsConstructorTest()
        {
            //arrange
            string id = "1717/8787";
            DateTime year = DateTime.Now;
            string type = "Journal";
            int idGroup = 1;
            //act
            var publication = new Statistic(id, year, type, idGroup);

            //assert
            publication.Id.Should().Be(id);
            publication.Year.Should().Be(year);
            publication.TypePublication.Should().Be(type);
            publication.ResearchGroupId.Should().Be(idGroup);
        }
    }
}
