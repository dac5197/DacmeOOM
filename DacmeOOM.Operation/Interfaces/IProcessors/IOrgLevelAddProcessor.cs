using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IProcessors
{
    public interface IOrgLevelAddProcessor
    {
        Task<CommandResponseModel<OrgLevelModel>> ProcessAsync(OrgLevelModel entity);
    }
}