using DacmeOOM.Core.Application.Factories;
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
    public class ProcessorFactoryUnitTests
    {
        [Fact]
        public void PropOrgLevel_WhenNew_ReturnsNewOrgLevelProcessorFactory()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new ProcessorFactory(serviceFactoryStub.Object);

            // Act
            var result = sut.OrgLevel;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<OrgLevelProcessorFactory>();
        }
    }
}
