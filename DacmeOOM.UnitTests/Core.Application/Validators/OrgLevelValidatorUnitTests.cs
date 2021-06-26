using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Application.Validators;
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

namespace DacmeOOM.UnitTests.Core.Application.Validators
{
    public class OrgLevelValidatorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task ValidateNameIsNotEmpty_WhenNameIsEmpty_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            entity.Name = "";

            List<OrgLevelModel> entities = new();
            entities.Add(entity);
            
            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetAsync()).ReturnsAsync(It.IsAny<List<OrgTypeModel>>());
            serviceFactoryStub.Setup(s => s.OrgLevel.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entity.Name);

            var expextError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);

            // Act
            var result = await sut.ValidateAsync(entity);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(entity.GetType().Name.Replace("Model", ""));

            result.Errors.Should().ContainEquivalentOf(expextError);
        }

        [Fact]
        public void ValidateNameIsNotEmpty_WhenNameIsValidString_DoesNotAddToErrors()
        {

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

        private ErrorModel CreateErrorModel(string propertyName, string propertyToTest)
        {
            ErrorModel error = new()
            {
                PropertyName = propertyName,
                Message = propertyToTest,
            };

            return error;
        }
    }
}
