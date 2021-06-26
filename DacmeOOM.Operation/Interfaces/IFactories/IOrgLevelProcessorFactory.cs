using DacmeOOM.Core.Application.Interfaces.IProcessors;

namespace DacmeOOM.Core.Application.Interfaces.IFactories
{
    public interface IOrgLevelProcessorFactory
    {
        IOrgLevelGetAllProcessor GetAll { get; }
        IOrgLevelGetByIdProcessor GetById { get; }
    }
}