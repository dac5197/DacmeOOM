using DacmeOOM.Core.Application.Interfaces.IFactories;
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
    public class OrgLevelGetByIdProcessorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task GetById_WithExistingEntity_ReturnsOrgLevelModel()
        {
            // Arrange
            var expectedEntity = CreateRandomOrgLevelModel();
            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgLevel.GetAsync(It.IsAny<int>())).ReturnsAsync(expectedEntity);

            var sut = new OrgLevelGetByIdProcessor(serviceFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(_rand.Next(1, 100));

            // Assert
            result
                .Should().BeOfType<OrgLevelModel>()
                .And.Should().NotBeNull()
                .And.Should().BeEquivalentTo(expectedEntity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetById_WithNotExistingEntity_ReturnsNull()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgLevel.GetAsync(It.IsAny<int>())).ReturnsAsync((OrgLevelModel)null);

            var sut = new OrgLevelGetByIdProcessor(serviceFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(_rand.Next(1, 100));

            // Assert
            result
                .Should().BeNull();

        }

        private OrgLevelModel CreateRandomOrgLevelModel()
        {
            OrgLevelModel entity = new()
            {
                Id = _rand.Next(1, 9999),
                Name = $"Name{ _rand.Next(1, 100) }",
                Level = _rand.Next(0, 99),
                OrgTypeId = _rand.Next(1, 99)
            };

            return entity;
        }
    }
}
