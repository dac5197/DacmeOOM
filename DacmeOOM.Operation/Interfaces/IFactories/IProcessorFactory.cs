namespace DacmeOOM.Core.Application.Interfaces.IFactories
{
    public interface IProcessorFactory
    {
        IOrgLevelProcessorFactory OrgLevel { get; }
    }
}