using DacmeOOM.Core.Application.Interfaces;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Validators
{
    public class OrgTypeValidator : BaseValidator, IOrgTypeValidator
    {
        public async Task<ErrorListModel> ValidateAsync(OrgTypeModel entity)
        {
            InitializeErrors(entity.GetType().Name.Replace("Model", ""));

            Validate_Name_IsNotEmpty(entity);
            Validate_Name_IsLessThan51Char(entity);

            return await Task.FromResult(ErrorsList);
        }

        private void Validate_Name_IsNotEmpty(OrgTypeModel entity)
        {
            var propertyName = nameof(entity.Name);
            var propertyToTest = entity.Name;

            if (String.IsNullOrEmpty(propertyToTest))
            {
                AddToErrors(propertyName, $"'{ propertyName }' cannot be empty or null.");
            }
        }

        private void Validate_Name_IsLessThan51Char(OrgTypeModel entity)
        {
            var propertyName = nameof(entity.Name);
            var propertyToTest = entity.Name;

            if (propertyToTest.Length > 50)
            {
                AddToErrors(propertyName, $"'{ propertyName }' legnth ({ propertyToTest.Length }) exceeds maximum length (50).");
            }
        }
    }
}
