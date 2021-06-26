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
        public async Task ValidateAsync_WhenEntityIsInvalid_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            var fkEntity = CreateRandomOrgTypeModel();
            entity.Name = "";
            entity.OrgTypeId = fkEntity.Id;

            List<OrgLevelModel> entities = new();
            entities.Add(entity);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetAsync(It.IsAny<int>())).ReturnsAsync(fkEntity);
            serviceFactoryStub.Setup(s => s.OrgLevel.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);

            // Act
            var result = await sut.ValidateAsync(entity);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public async Task ValidateAsync_WhenEntityIsValid_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            var fkEntity = CreateRandomOrgTypeModel();
            entity.OrgTypeId = fkEntity.Id;

            List<OrgLevelModel> entities = new();
            entities.Add(entity);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetAsync(It.IsAny<int>())).ReturnsAsync(fkEntity);
            serviceFactoryStub.Setup(s => s.OrgLevel.GetUntrackedAsync()).ReturnsAsync(entities);

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);

            // Act
            var result = await sut.ValidateAsync(entity);

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateNameIsNotEmpty_WhenNameIsEmpty_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            entity.Name = "";
            
            var serviceFactoryStub = new Mock<IServiceFactory>();

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsNotEmpty(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public void ValidateNameIsNotEmpty_WhenNameIsValidString_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsNotEmpty(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateNameIsLessThan50Char_WhenNameIsGreaterThan50Char_AddsToErrors()
        {

            // Arrange
            var entity = CreateRandomOrgLevelModel();
            entity.Name = "abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789";

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' legnth ({ entity.Name.Length }) exceeds maximum length (50).");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsLessThan50Char(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public void ValidateNameIsLessThan50Char_WhenNameIsLessThan50Char_DoesNotAddToErrors()
        {

            // Arrange
            var entity = CreateRandomOrgLevelModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsLessThan50Char(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void ValidateLevelIsPostive_WhenLevelIsNegative_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            entity.Level = -5;

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var propertyName = nameof(entity.Level);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' value ({ entity.Level }) must be a postive integer.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Level_IsPostive(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public void ValidateLevelIsPostive_WhenLevelIsPostive_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Level_IsPostive(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task ValidateFkOrgTypeEntityExistsInDb_WhenFkOrgTypeEntityDoesNotExist_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetAsync(It.IsAny<int>())).ReturnsAsync((OrgTypeModel)null);

            var propertyName = nameof(entity.OrgTypeId);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' ({entity.OrgTypeId}) not found in database.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            await sut.Validate_FkOrgTypeEntity_ExistsInDb(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public async Task ValidateFkOrgTypeEntityExistsInDb_WhenFkOrgTypeEntityDoesExist_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();
            var fkEntity = CreateRandomOrgTypeModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetAsync(It.IsAny<int>())).ReturnsAsync(fkEntity);

            var propertyName = nameof(entity.OrgTypeId);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' ({entity.OrgTypeId}) not found in database.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            await sut.Validate_FkOrgTypeEntity_ExistsInDb(entity);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entity));

            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public async Task ValidateOrgLevelEntityExistsInDb_WhenEntityDoesNotExist_AddsToErrors()
        {
            // Arrange
            var entityToTest = CreateRandomOrgLevelModel();
            var randomEntity1 = CreateRandomOrgLevelModel();
            var randomEntity2 = CreateRandomOrgLevelModel();
            var randomEntity3 = CreateRandomOrgLevelModel();
            var randomEntity4 = CreateRandomOrgLevelModel();
            var randomEntity5 = CreateRandomOrgLevelModel();

            List<OrgLevelModel> entities = new();
            entities.Add(randomEntity1);
            entities.Add(randomEntity2);
            entities.Add(randomEntity3);
            entities.Add(randomEntity4);
            entities.Add(randomEntity5);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgLevel.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entityToTest.Id);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' not found in database.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entityToTest));

            // Act
            await sut.Validate_OrgLevelEntity_ExistsInDb(entityToTest);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entityToTest));

            result.Errors.Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public async Task ValidateOrgLevelEntityExistsInDb_WhenEntityDoesExist_DoesNotAddToErrors()
        {
            // Arrange
            var entityToTest = CreateRandomOrgLevelModel();
            var randomEntity1 = CreateRandomOrgLevelModel();
            var randomEntity2 = CreateRandomOrgLevelModel();
            var randomEntity3 = CreateRandomOrgLevelModel();
            var randomEntity4 = CreateRandomOrgLevelModel();
            var randomEntity5 = CreateRandomOrgLevelModel();

            List<OrgLevelModel> entities = new();
            entities.Add(entityToTest);
            entities.Add(randomEntity1);
            entities.Add(randomEntity2);
            entities.Add(randomEntity3);
            entities.Add(randomEntity4);
            entities.Add(randomEntity5);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgLevel.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entityToTest.OrgTypeId);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' not found in database.");

            var sut = new OrgLevelValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entityToTest));

            // Act
            await sut.Validate_OrgLevelEntity_ExistsInDb(entityToTest);
            var result = sut.ErrorsList;

            // Assert
            result.Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName.Should().Be(GetEntityName(entityToTest));

            result.Errors.Should().BeEmpty();
        }

        private static string GetEntityName(OrgLevelModel entity)
        {
            return entity.GetType().Name.Replace("Model", "");
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

        private OrgTypeModel CreateRandomOrgTypeModel()
        {
            OrgTypeModel entity = new()
            {
                Id = _rand.Next(1, 9999),
                Name = $"OrgTypeModelName{ _rand.Next(1, 100) }",
                Created = DateTime.Now,
                Updated = DateTime.Now
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
