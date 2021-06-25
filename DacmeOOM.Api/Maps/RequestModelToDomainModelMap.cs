using AutoMapper;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Maps
{
    public class RequestModelToDomainModelMap : Profile
    {
        public RequestModelToDomainModelMap()
        {
            // OrgLevel
            CreateMap<OrgLevelPostRequestModel, OrgLevelModel>();
            CreateMap<OrgLevelPutRequestModel, OrgLevelModel>();

            // OrgType
            CreateMap<OrgTypePostRequestModel, OrgTypeModel>();
            CreateMap<OrgTypePutRequestModel, OrgTypeModel>();
        }
    }
}
