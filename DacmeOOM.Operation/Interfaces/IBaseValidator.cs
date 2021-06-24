using DacmeOOM.Core.Application.Models;

namespace DacmeOOM.Core.Application.Interfaces
{
    public interface IBaseValidator
    {
        ErrorListModel ErrorsList { get; set; }

        void AddToErrors(string propertyName, string message);
        void InitializeErrors();
    }
}