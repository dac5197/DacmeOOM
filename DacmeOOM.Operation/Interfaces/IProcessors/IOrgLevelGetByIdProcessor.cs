using DacmeOOM.Core.Domain.Models;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IProcessors
{
    public interface IOrgLevelGetByIdProcessor
    {
        Task<OrgLevelModel> ProcessAsync(int id);
    }
}