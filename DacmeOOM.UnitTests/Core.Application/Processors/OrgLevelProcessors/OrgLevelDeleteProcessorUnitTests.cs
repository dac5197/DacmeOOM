using DacmeOOM.Core.Application.Processors.OrgLevelProcessors;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DacmeOOM.UnitTests.Core.Application.Processors.OrgLevelProcessors
{
    public class OrgLevelDeleteProcessorUnitTests
    {
        [Fact]
        public async Task Delete_EntityExists_ReturnsTrue()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            //serviceFactoryStub.Setup(x => x.OrgLevel.GetAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<OrgLevelModel>());
            serviceFactoryStub.Setup(x => x.OrgLevel.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            var sut = new OrgLevelDeleteProcessor(serviceFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(5);

            // Assert
            result
                .Should().BeTrue();
        }

        [Fact]
        public async Task Delete_EntityDoesNotExists_ReturnsFalse()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            //serviceFactoryStub.Setup(x => x.OrgLevel.GetAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<OrgLevelModel>());
            serviceFactoryStub.Setup(x => x.OrgLevel.DeleteAsync(It.IsAny<int>())).ReturnsAsync(false);

            var sut = new OrgLevelDeleteProcessor(serviceFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(5);

            // Assert
            result
                .Should().BeFalse();
        }
    }
}
