namespace DacmeOOM.Core.Application.Interfaces
{
    public interface IValidatorFactory
    {
        IOrgLevelValidator OrgLevel { get; }
        IOrgTypeValidator OrgType { get; }
    }
}