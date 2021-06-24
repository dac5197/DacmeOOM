using DacmeOOM.Core.Application.Interfaces;

namespace DacmeOOM.Core.Application.Factories
{
    interface IValidatorFactory
    {
        IOrgTypeValidator OrgType { get; }
    }
}