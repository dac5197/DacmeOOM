namespace DacmeOOM.Core.Domain.Interfaces
{
    public interface IServiceFactory
    {
        IOrgLevelService OrgLevel { get; }
        IOrgTypeService OrgType { get;  }
    }
}