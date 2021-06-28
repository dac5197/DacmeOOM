using AutoMapper;
using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Application.Queries.OrgTypeQueries;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using DacmeOOM.Web.Api.Controllers.V1;
using DacmeOOM.Web.Api.Maps;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DacmeOOM.UnitTests.Web.Api
{
    public class OrgTypeControllerUnitTests
    {
        private readonly Random _rand = new();

        [Fact]
        public async Task Get_WhenItemsExist_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = InjectMapper();

            List<OrgLevelModel> entityList = new();

            for (int i = 0; i < 5; i++)
            {
                entityList.Add(CreateRandomOrgLevelModel());
            }

            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.GetAll.ProcessAsync()).ReturnsAsync(entityList);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Get();
            var objectResult = result as ObjectResult;

            // Assert
            objectResult
                .Should().BeOfType<OkObjectResult>();

            objectResult.StatusCode
                .Should().Be(StatusCodes.Status200OK);

            objectResult.Value
                .Should().BeOfType<List<OrgLevelResponseModel>>()
                .And.Should().NotBeNull();

            objectResult.Value
                .Should().BeEquivalentTo(entityList, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Get_WhenItemsDoNotExist_ReturnsOkResult()
        {
            // Arrange
            var mapperMock = InjectMapper();

            List<OrgLevelModel> emptyList = new();

            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.GetAll.ProcessAsync()).ReturnsAsync((List<OrgLevelModel>)null);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Get();
            var objectResult = result as ObjectResult;

            // Assert
            objectResult
                .Should().BeOfType<OkObjectResult>();

            objectResult.StatusCode
                .Should().Be(StatusCodes.Status200OK);

            objectResult.Value
                .Should().BeOfType<List<OrgLevelResponseModel>>()
                .And.Should().NotBeNull();

            objectResult.Value
                .Should().BeEquivalentTo(emptyList, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetId_WhenItemExists_ReturnsOkResulst()
        {
            // Arrange
            var mapperMock = InjectMapper();

            var entity = CreateRandomOrgLevelModel();

            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.GetById.ProcessAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Get(5);
            var objectResult = result as ObjectResult;

            // Assert
            objectResult
                .Should().BeOfType<OkObjectResult>();

            objectResult.StatusCode
                .Should().Be(StatusCodes.Status200OK);

            objectResult.Value
                .Should().BeOfType<OrgLevelResponseModel>()
                .And.Should().NotBeNull();

            objectResult.Value
                .Should().BeEquivalentTo(entity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetId_WhenItemDoesNotExist_ReturnsNotFoundResult ()
        {
            // Arrange
            var mapperMock = InjectMapper();
            
            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.GetById.ProcessAsync(It.IsAny<int>())).ReturnsAsync((OrgLevelModel)null);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Get(5);

            // Assert
            result
                .Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Post_WhenResultIsValid_ReturnsOkResult()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            OrgLevelPostRequestModel postRequestModel = new()
            {
                Name = entity.Name,
                Level = entity.Level,
                OrgTypeId = entity.OrgTypeId
            };

            var response = CreateCommandResponseModel(entity, true);

            var mapperMock = InjectMapper();

            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.Add.ProcessAsync(It.IsAny<OrgLevelModel>())).ReturnsAsync(response);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Post(postRequestModel);
            var objectResult = result as ObjectResult;

            // Assert
            objectResult
               .Should().BeOfType<OkObjectResult>();

            objectResult.StatusCode
                .Should().Be(StatusCodes.Status200OK);

            objectResult.Value
                .Should().BeOfType<OrgLevelResponseModel>()
                .And.Should().NotBeNull();

            objectResult.Value
                .Should().BeEquivalentTo(entity, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task Post_WhenResultIsInvalid_ReturnsBadResult()
        {
            // Arrange
            var entity = CreateRandomOrgLevelModel();

            OrgLevelPostRequestModel postRequestModel = new()
            {
                Name = entity.Name,
                Level = entity.Level,
                OrgTypeId = entity.OrgTypeId
            };

            var response = CreateCommandResponseModel(entity, false);

            var mapperMock = InjectMapper();

            var processorFactoryStub = new Mock<IProcessorFactory>();
            processorFactoryStub.Setup(x => x.OrgLevel.Add.ProcessAsync(It.IsAny<OrgLevelModel>())).ReturnsAsync(response);

            var serviceFactoryStub = new Mock<IServiceFactory>();

            var sut = new OrgLevelController(processorFactoryStub.Object, serviceFactoryStub.Object, mapperMock);

            // Act
            var result = await sut.Post(postRequestModel);
            var objectResult = result as ObjectResult;

            // Assert
            objectResult
               .Should().BeOfType<BadRequestObjectResult>();

            objectResult.StatusCode
                .Should().Be(StatusCodes.Status400BadRequest);

            objectResult.Value
                .Should().BeOfType<ErrorListReponseModel>()
                .And.Should().NotBeNull();

            objectResult.Value
                .Should().BeEquivalentTo(response, options => options.ExcludingMissingMembers());
        }

        private static CommandResponseModel<OrgLevelModel> CreateCommandResponseModel(OrgLevelModel entity, bool isValid)
        {
            CommandResponseModel<OrgLevelModel> response = new() 
            { 
                Entity = entity,
            };

            if (isValid is false)
            {
                response.ErrorList = new();
                response.ErrorList.Errors = new();
                response.ErrorList.Errors.Add(
                    new ErrorModel
                    {
                        PropertyName = "TestError",
                        Message = "Test error message.  This is only a test"
                    });
            }

            return response;
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

        private static IMapper InjectMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationModelToResponseModelMap());
                mc.AddProfile(new DomainModelToResponseModelMap());
                mc.AddProfile(new RequestModelToDomainModelMap());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            
            return mapper;
        }
    }
}
