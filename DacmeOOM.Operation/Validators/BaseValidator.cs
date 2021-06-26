using DacmeOOM.Core.Application.Interfaces.IValidators;
using DacmeOOM.Core.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Validators
{
    public class BaseValidator : IBaseValidator
    {
        public ErrorListModel ErrorsList { get; set; }

        public void AddToErrors(string propertyName, string message)
        {
            if (String.IsNullOrWhiteSpace(propertyName) || String.IsNullOrWhiteSpace(message))
            {
                return;
            }

            ErrorModel error = new()
            {
                PropertyName = propertyName,
                Message = message
            };

            ErrorsList.Errors.Add(error);
        }

        public void InitializeErrors(string entityName)
        {
            ErrorsList = new();
            ErrorsList.Errors = new();
            ErrorsList.EntityName = entityName;
        }
    }
}
