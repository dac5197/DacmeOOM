using DacmeOOM.Core.Application.Interfaces.IValidators;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Interfaces;
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
        private readonly IServiceFactory _serviceFactory;

        public OrgTypeValidator(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<ErrorListModel> ValidateAsync(OrgTypeModel entity)
        {
            InitializeErrors(entity.GetType().Name.Replace("Model", ""));

            if (entity.Id != 0)
            {
                await Validate_OrgTypeEntity_ExistsInDb(entity);
            }

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

        private async Task Validate_OrgTypeEntity_ExistsInDb(OrgTypeModel entity)
        {
            var propertyName = nameof(entity.Id);
            var entitiesInDb = await _serviceFactory.OrgType.GetUntrackedAsync();
            var entityInDb = entitiesInDb.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (entityInDb is null)
            {
                AddToErrors(propertyName, $"'{ propertyName }' not found in database.");
            }
        }
    }
}
