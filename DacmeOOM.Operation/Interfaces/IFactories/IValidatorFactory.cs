using DacmeOOM.Core.Application.Interfaces.IValidators;

namespace DacmeOOM.Core.Application.Interfaces.IFactories
{
    public interface IValidatorFactory
    {
        IOrgLevelValidator OrgLevel { get; }
        IOrgTypeValidator OrgType { get; }
    }
}