using DacmeOOM.Core.Application.Factories;
using DacmeOOM.Core.Application.Interfaces.IValidators;
using DacmeOOM.Core.Application.Validators;
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
    public class ValidatorFactoryUnitTests
    {
        [Fact]
        public void PropOrgLevel_WhenNew_ReturnsNewOrgLevelValidator()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new ValidatorFactory(serviceFactoryStub.Object);

            // Act
            var result = sut.OrgLevel;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<OrgLevelValidator>();
        }

        [Fact]
        public void PropOrgType_WhenNew_ReturnsNewOrgTypeValidator()
        {
            // Arrange
            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new ValidatorFactory(serviceFactoryStub.Object);

            // Act
            var result = sut.OrgType;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<OrgTypeValidator>();
        }
    }
}
