using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Application.Validators;
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
    public class BaseValidatorUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public void AddToErrors_WhenPropertyNameIsNull_DoesNotAddToErrors()
        {
            // Arrange
            var sut = new BaseValidator();
            sut.InitializeErrors(It.IsAny<string>());

            // Act
            sut.AddToErrors(null, It.IsAny<string>());

            var result = sut.ErrorsList.Errors;

            // Assert
            result
                .Should().BeEmpty();
        }

        [Fact]
        public void AddToErrors_WhenPropertyNameIsEmptyString_DoesNotAddToErrors()
        {
            // Arrange
            var sut = new BaseValidator();
            sut.InitializeErrors(It.IsAny<string>());

            // Act
            sut.AddToErrors("", It.IsAny<string>());

            var result = sut.ErrorsList.Errors;

            // Assert
            result
                .Should().BeEmpty();
        }

        [Fact]
        public void AddToErrors_WhenMessageIsNull_DoesNotAddToErrors()
        {
            // Arrange
            var sut = new BaseValidator();
            sut.InitializeErrors(It.IsAny<string>());

            // Act
            sut.AddToErrors(It.IsAny<string>(), null);

            var result = sut.ErrorsList.Errors;

            // Assert
            result
                .Should().BeEmpty();
        }

        [Fact]
        public void AddToErrors_WhenMessageEmptyString_DoesNotAddToErrors()
        {
            // Arrange
            var sut = new BaseValidator();
            sut.InitializeErrors(It.IsAny<string>());

            // Act
            sut.AddToErrors(It.IsAny<string>(), "");

            var result = sut.ErrorsList.Errors;

            // Assert
            result
                .Should().BeEmpty();
        }

        [Fact]
        public void AddToErrors_WhenPropertyNameMessageAreValidStrings_AddsToErrors()
        {
            // Arrange
            var sut = new BaseValidator();
            sut.InitializeErrors(It.IsAny<string>());

            var error = CreateRandomErrorModel();

            // Act
            sut.AddToErrors(error.PropertyName, error.Message);

            var result = sut.ErrorsList.Errors;

            // Assert
            result
                .Should().ContainEquivalentOf(error);
        }

        [Fact]
        public void InitializeErrors_WhenEntityNameIsValidString_SetsErrorsListEntityName()
        {
            // Arrange
            var sut = new BaseValidator();
            var randEntityName = $"entityName{ _rand.Next(0, 999) }";

            // Act
            sut.InitializeErrors(randEntityName);
            var result = sut.ErrorsList;

            // Assert
            result.EntityName
                .Should().Be(randEntityName);

            result.Errors
                .Should().BeOfType<List<ErrorModel>>()
                .And.Should().NotBeNull();
        }

        private ErrorModel CreateRandomErrorModel()
        {
            ErrorModel randError = new() 
            { 
                PropertyName = $"propertyName{ _rand.Next(0, 1000) }",
                Message = $"message #{ _rand.Next(0, 1000000) }"
            };

            return randError;
        }
    }
}
