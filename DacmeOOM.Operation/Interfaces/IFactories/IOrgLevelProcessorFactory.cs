using DacmeOOM.Core.Application.Interfaces.IProcessors;

namespace DacmeOOM.Core.Application.Interfaces.IFactories
{
    public interface IOrgLevelProcessorFactory
    {
        IGetAllOrgLevelListProcessor GetAll { get; }
        IGetOrgLevelByIdProcessor GetById { get; }
    }
}