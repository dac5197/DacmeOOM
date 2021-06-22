namespace DacmeOOM.Application.Interfaces
{
    public interface IHandlerFactory
    {
        IOrgLevelHandler OrgLevel { get; }
        IOrgTypeHandler OrgType { get;  }
    }
}