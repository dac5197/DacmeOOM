using AutoMapper;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Maps
{
    public class RequestModelToEntityModelMap : Profile
    {
        public RequestModelToEntityModelMap()
        {
            CreateMap<OrgLevelRequestModel, OrgLevelModel>();
            CreateMap<OrgTypeRequestModel, OrgTypeModel>();
        }
    }
}
