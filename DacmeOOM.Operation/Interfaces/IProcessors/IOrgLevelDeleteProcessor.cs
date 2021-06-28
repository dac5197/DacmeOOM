using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Interfaces.IProcessors
{
    public interface IOrgLevelDeleteProcessor
    {
        Task<bool> ProcessAsync(int id);
    }
}