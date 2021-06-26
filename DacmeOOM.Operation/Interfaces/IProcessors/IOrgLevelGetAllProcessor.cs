using DacmeOOM.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IProcessors
{
    public interface IOrgLevelGetAllProcessor
    {
        Task<List<OrgLevelModel>> ProcessAsync();
    }
}