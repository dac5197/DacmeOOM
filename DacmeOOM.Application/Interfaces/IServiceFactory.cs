namespace DacmeOOM.Application.Interfaces
{
    public interface IServiceFactory
    {
        IOrgLevelService OrgLevel { get; }
        IOrgTypeService OrgType { get;  }
    }
}