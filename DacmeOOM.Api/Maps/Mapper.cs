using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Maps
{
    public class Mapper : IMapper
    {
        public OrgLevelResponseModel EntityModelToResponseModel(OrgLevelModel entityModel)
        {
            var responseModel = new OrgLevelResponseModel()
            {
                Id = entityModel.Id,
                Name = entityModel.Name,
                Level = entityModel.Level,
                OrgTypeId = entityModel.OrgTypeId,
                Created = entityModel.Created,
                Updated = entityModel.Updated
            };

            return responseModel;
        }

        

        public OrgLevelModel RequestModelToEntityModel(OrgLevelRequestModel requestModel)
        {
            var entityModel = new OrgLevelModel()
            {
                Name = requestModel.Name,
                Level = requestModel.Level,
                OrgTypeId = requestModel.OrgTypeId
            };

            return entityModel;
        }



    }
}
