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
            CreateMap<OrgLevelRequestModel, OrgLevelModel>();
            CreateMap<OrgTypeRequestModel, OrgTypeModel>();
        }
    }
}
