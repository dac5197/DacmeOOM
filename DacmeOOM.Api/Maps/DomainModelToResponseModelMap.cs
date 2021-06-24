using AutoMapper;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Maps
{
    public class DomainModelToResponseModelMap : Profile
    {
        public DomainModelToResponseModelMap()
        {
            CreateMap<OrgLevelModel, OrgLevelResponseModel>();
            CreateMap<OrgTypeModel, OrgTypeResponseModel>();
        }
    }
}
