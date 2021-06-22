using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;

namespace DacmeOOM.Web.Api.Maps
{
    public interface IMapper
    {
        OrgLevelResponseModel EntityModelToResponseModel(OrgLevelModel entityModel);
        OrgLevelModel RequestModelToEntityModel(OrgLevelRequestModel requestModel);
    }
}