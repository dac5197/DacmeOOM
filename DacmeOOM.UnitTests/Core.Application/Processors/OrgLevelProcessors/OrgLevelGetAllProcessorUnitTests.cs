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
    public class OrgLevelGetAllProcessorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task GetAll_WithExistingEntities_ReturnsAllEntities()
        {
            // Arrange
            int entityCount = 5;
            var expectEntities = CreateRandomOrgLevelModelList(entityCount);
            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgLevel.GetAsync()).ReturnsAsync(expectEntities);

            var sut = new OrgLevelGetAllProcessor(serviceFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync();

            // Assert
            result.Should().BeEquivalentTo(expectEntities, options => options.ExcludingMissingMembers())
                .And.HaveCount(entityCount);
        }

        private List<OrgLevelModel> CreateRandomOrgLevelModelList(int count)
        {
            List<OrgLevelModel> entities = new();

            for (int i = 0; i < count; i++)
            {
                OrgLevelModel entity = new()
                {
                    Id = _rand.Next(1, 9999),
                    Name = $"Name{ _rand.Next(1, 100) }",
                    Level = _rand.Next(0, 99),
                    OrgTypeId = _rand.Next(1, 99)
                };

                entities.Add(entity);
            }

            return entities;
        }
    }
}
