using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IProcessors
{
    public interface IGetOrgLevelByIdProcessor
    {
        Task<OrgLevelModel> Process(int id);
    }
}