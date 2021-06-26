using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IValidators
{
    public interface IOrgLevelValidator
    {
        Task<ErrorListModel> ValidateAsync(OrgLevelModel entity);
        void Validate_Name_IsNotEmpty(OrgLevelModel entity);
        void Validate_Name_IsLessThan50Char(OrgLevelModel entity);
        void Validate_Level_IsPostive(OrgLevelModel entity);
        Task Validate_FkOrgTypeEntity_ExistsInDb(OrgLevelModel entity);
        Task Validate_OrgLevelEntity_ExistsInDb(OrgLevelModel entity);
    }
}