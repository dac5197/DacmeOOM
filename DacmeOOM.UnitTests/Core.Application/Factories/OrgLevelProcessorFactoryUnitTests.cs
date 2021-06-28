using DacmeOOM.Core.Application.Factories;
using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Processors.OrgLevelProcessors;
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
        public void PropGetAll_WhenNew_ReturnsNewOrgLevelGetAllProcessor()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            var validatorFactoryStub = new Mock<IValidatorFactory>();

            var sut = new OrgLevelProcessorFactory(serviceFactoryStub.Object, validatorFactoryStub.Object);

            // Act
            var result = sut.GetAll;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<OrgLevelGetAllProcessor>();
        }

        [Fact]
        public void PropGetById_WhenNew_ReturnsNewOrgLevelGetAllProcessor()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();
            var validatorFactoryStub = new Mock<IValidatorFactory>();

            var sut = new OrgLevelProcessorFactory(serviceFactoryStub.Object, validatorFactoryStub.Object);

            // Act
            var result = sut.GetById;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<OrgLevelGetByIdProcessor>();
        }
    }
}
