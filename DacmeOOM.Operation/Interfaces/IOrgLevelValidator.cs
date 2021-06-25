using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces
{
    public interface IOrgLevelValidator
    {
        Task<ErrorListModel> ValidateAsync(OrgLevelModel entity);
    }
}