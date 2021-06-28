using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Models;
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
    public class OrgLevelAddProcessorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task Add_WhenEntityIsValid_ReturnsResponseIsValidIsTrue()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            var entityErrors = new ErrorListModel();
            entityErrors.Errors = new();

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(x => x.OrgLevel.AddAsync(entity)).ReturnsAsync(entity);

            var validatorFactoryStub = new Mock<IValidatorFactory>();
            validatorFactoryStub.Setup(x => x.OrgLevel.ValidateAsync(It.IsAny<OrgLevelModel>())).ReturnsAsync(entityErrors);

            var sut = new OrgLevelAddProcessor(serviceFactoryStub.Object, validatorFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(entity);

            // Assert
            result.IsValid.Should().BeTrue();

            result.Entity.Should().BeOfType<OrgLevelModel>()
                .And.BeEquivalentTo(entity);
        }

        [Fact]
        public async Task Add_WhenEntityIsInvalid_ReturnsResponseIsValidIsFalseAndContainsErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            ErrorModel error = new()
            {
                PropertyName = "TestProperty",
                Message = "Test error message.  This is only a test."
            };

            ErrorListModel entityErrors = new();
            entityErrors.Errors = new();
            entityErrors.Errors.Add(error);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(x => x.OrgLevel.AddAsync(entity)).ReturnsAsync(entity);

            var validatorFactoryStub = new Mock<IValidatorFactory>();
            validatorFactoryStub.Setup(x => x.OrgLevel.ValidateAsync(It.IsAny<OrgLevelModel>())).ReturnsAsync(entityErrors);

            var sut = new OrgLevelAddProcessor(serviceFactoryStub.Object, validatorFactoryStub.Object);

            // Act
            var result = await sut.ProcessAsync(entity);

            // Assert
            result.IsValid.Should().BeFalse();

            result.ErrorList.Should().NotBeNull();

            result.ErrorList.Errors.Should().Contain(error);

            result.Entity.Should().BeOfType<OrgLevelModel>()
                .And.BeEquivalentTo(entity);
        }

        private OrgLevelModel CreateRandomOrgLevelModel()
        {
            OrgLevelModel entity = new()
            {
                Id = _rand.Next(1, 9999),
                Name = $"OrgLevelModelName{ _rand.Next(1, 100) }",
                Level = _rand.Next(0, 99),
                OrgTypeId = _rand.Next(1, 99)
            };

            return entity;
        }
    }
}
