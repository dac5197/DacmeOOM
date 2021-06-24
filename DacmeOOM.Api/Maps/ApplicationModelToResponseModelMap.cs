using AutoMapper;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Maps
{
    public class ApplicationModelToResponseModelMap : Profile
    {
        public ApplicationModelToResponseModelMap()
        {
            CreateMap<ErrorModel, ErrorResponseModel>();
            CreateMap<ErrorListModel, ErrorListReponseModel>();
        }
    }
}
