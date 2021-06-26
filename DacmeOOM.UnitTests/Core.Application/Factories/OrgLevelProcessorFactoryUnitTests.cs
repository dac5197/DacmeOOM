using DacmeOOM.Core.Application.Factories;
using DacmeOOM.Core.Application.Interfaces.IProcessors;
using DacmeOOM.Core.Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DacmeOOM.UnitTests.Core.Application.Factories
{
    public class OrgLevelProcessorFactoryUnitTests
    {
        [Fact]
        public void PropGetById_WhenNull_ReturnsOrgLevelGetByIdProcessor()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            //var orgLevelGetAllProcessorStub = new Mock<IOrgLevelGetAllProcessor>();
            //var orgLevelByIdProcessorStub = new Mock<IOrgLevelGetByIdProcessor>();

            var sut = new OrgLevelProcessorFactory(serviceFactoryStub.Object);

            // Act

            var result = sut.GetById;

            // Assert
            result.Should().BeOfType<IOrgLevelGetByIdProcessor>();

        }
    }
}
