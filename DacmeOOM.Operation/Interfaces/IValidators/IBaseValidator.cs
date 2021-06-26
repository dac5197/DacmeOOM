using DacmeOOM.Core.Application.Models;

namespace DacmeOOM.Core.Application.Interfaces.IValidators
{
    public interface IBaseValidator
    {
        ErrorListModel ErrorsList { get; set; }

        void AddToErrors(string propertyName, string message);
        void InitializeErrors(string entityName);
    }
}