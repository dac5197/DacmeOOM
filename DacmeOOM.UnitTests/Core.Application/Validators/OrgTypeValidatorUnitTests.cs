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
    public class OrgTypeValidatorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task ValidateAsync_WhenEntityIsInvalid_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgTypeModel();
            entity.Name = "";

            List<OrgTypeModel> entities = new();
            entities.Add(entity);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);

            // Act
            var result = await sut.ValidateAsync(entity);

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public async Task ValidateAsync_WhenEntityIsValid_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgTypeModel();

            List<OrgTypeModel> entities = new();
            entities.Add(entity);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);

            // Act
            var result = await sut.ValidateAsync(entity);

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().BeEmpty();
        }


        [Fact]
        public void ValidateNameIsNotEmpty_WhenNameIsEmpty_AddsToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgTypeModel();
            entity.Name = "";

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' cannot be empty or null.");

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsNotEmpty(entity);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public void ValidateNameIsNotEmpty_WhenNameIsValidString_DoesNotAddToErrors()
        {
            // Arrange
            var entity = CreateRandomOrgTypeModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsNotEmpty(entity);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().BeEmpty();
        }

        [Fact]
        public void ValidateNameIsLessThan50Char_WhenNameIsGreaterThan50Char_AddsToErrors()
        {

            // Arrange
            var entity = CreateRandomOrgTypeModel();
            entity.Name = "abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789";

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var propertyName = nameof(entity.Name);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' legnth ({ entity.Name.Length }) exceeds maximum length (50).");

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsLessThan50Char(entity);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public void ValidateNameIsLessThan50Char_WhenNameIsLessThan50Char_DoesNotAddToErrors()
        {

            // Arrange
            var entity = CreateRandomOrgTypeModel();

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entity));

            // Act
            sut.Validate_Name_IsLessThan50Char(entity);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entity));

            result.Errors
                .Should().BeEmpty();
        }

        [Fact]
        public async Task ValidateOrgTypeEntityExistsInDb_WhenEntityDoesNotExist_AddsToErrors()
        {
            // Arrange
            var entityToTest = CreateRandomOrgTypeModel();
            var randomEntity1 = CreateRandomOrgTypeModel();
            var randomEntity2 = CreateRandomOrgTypeModel();
            var randomEntity3 = CreateRandomOrgTypeModel();
            var randomEntity4 = CreateRandomOrgTypeModel();
            var randomEntity5 = CreateRandomOrgTypeModel();

            List<OrgTypeModel> entities = new();
            entities.Add(randomEntity1);
            entities.Add(randomEntity2);
            entities.Add(randomEntity3);
            entities.Add(randomEntity4);
            entities.Add(randomEntity5);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetUntrackedAsync()).ReturnsAsync(entities);

            var propertyName = nameof(entityToTest.Id);

            var expextedError = CreateErrorModel(propertyName, $"'{ propertyName }' not found in database.");

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entityToTest));

            // Act
            await sut.Validate_OrgTypeEntity_ExistsInDb(entityToTest);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entityToTest));

            result.Errors
                .Should().ContainEquivalentOf(expextedError);
        }

        [Fact]
        public async Task ValidateOrgTypeEntityExistsInDb_WhenEntityDoesExist_DoesNotAddToErrors()
        {
            // Arrange
            var entityToTest = CreateRandomOrgTypeModel();
            var randomEntity1 = CreateRandomOrgTypeModel();
            var randomEntity2 = CreateRandomOrgTypeModel();
            var randomEntity3 = CreateRandomOrgTypeModel();
            var randomEntity4 = CreateRandomOrgTypeModel();
            var randomEntity5 = CreateRandomOrgTypeModel();

            List<OrgTypeModel> entities = new();
            entities.Add(entityToTest);
            entities.Add(randomEntity1);
            entities.Add(randomEntity2);
            entities.Add(randomEntity3);
            entities.Add(randomEntity4);
            entities.Add(randomEntity5);

            var serviceFactoryStub = new Mock<IServiceFactory>();
            serviceFactoryStub.Setup(s => s.OrgType.GetUntrackedAsync()).ReturnsAsync(entities);

            var sut = new OrgTypeValidator(serviceFactoryStub.Object);
            sut.InitializeErrors(GetEntityName(entityToTest));

            // Act
            await sut.Validate_OrgTypeEntity_ExistsInDb(entityToTest);
            var result = sut.ErrorsList;

            // Assert
            result
                .Should().NotBeNull()
                .And.BeOfType<ErrorListModel>();

            result.EntityName
                .Should().Be(GetEntityName(entityToTest));

            result.Errors
                .Should().BeEmpty();
        }

        private static ErrorModel CreateErrorModel(string propertyName, string propertyToTest)
        {
            ErrorModel error = new()
            {
                PropertyName = propertyName,
                Message = propertyToTest,
            };

            return error;
        }

        private static string GetEntityName(OrgTypeModel entity)
        {
            return entity.GetType().Name.Replace("Model", "");
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
    }
}
