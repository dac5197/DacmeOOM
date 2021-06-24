namespace DacmeOOM.Core.Application.Interfaces
{
    public interface IValidatorFactory
    {
        IOrgTypeValidator OrgType { get; }
    }
}