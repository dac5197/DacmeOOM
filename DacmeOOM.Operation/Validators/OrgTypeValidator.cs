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
            ClearErrors();

            Validate_Name_IsNotEmpty(entity);

            return await Task.FromResult(ErrorsList);
        }

        private void Validate_Name_IsNotEmpty(OrgTypeModel entity)
        {
            var propertyName = nameof(entity.Name);
            var propertyToTest = entity.Name;

            if (String.IsNullOrEmpty(propertyToTest))
            {
                AddToErrors(propertyName, $"{ propertyName } cannot be empty or null.");
            }
        }
    }
}
