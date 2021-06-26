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
    public class OrgLevelValidator : BaseValidator, IOrgLevelValidator
    {
        private readonly IServiceFactory _serviceFactory;

        public OrgLevelValidator(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<ErrorListModel> ValidateAsync(OrgLevelModel entity)
        {
            InitializeErrors(entity.GetType().Name.Replace("Model", ""));

            if (entity.Id != 0)
            {
                await Validate_OrgLevelEntity_ExistsInDb(entity);
            }

            Validate_Name_IsNotEmpty(entity);
            Validate_Name_IsLessThan50Char(entity);
            Validate_Level_IsPostive(entity);

            await Validate_FkOrgTypeEntity_ExistsInDb(entity);

            return await Task.FromResult(ErrorsList);
        }

        public void Validate_Name_IsNotEmpty(OrgLevelModel entity)
        {
            var propertyName = nameof(entity.Name);
            var propertyToTest = entity.Name;

            if (String.IsNullOrEmpty(propertyToTest))
            {
                AddToErrors(propertyName, $"'{ propertyName }' cannot be empty or null.");
            }
        }

        public void Validate_Name_IsLessThan50Char(OrgLevelModel entity)
        {
            var propertyName = nameof(entity.Name);
            var propertyToTest = entity.Name;

            if (propertyToTest.Length > 50)
            {
                AddToErrors(propertyName, $"'{ propertyName }' legnth ({ propertyToTest.Length }) exceeds maximum length (50).");
            }
        }

        public void Validate_Level_IsPostive(OrgLevelModel entity)
        {
            var propertyName = nameof(entity.Level);
            var propertyToTest = entity.Level;

            if (propertyToTest < 0)
            {
                AddToErrors(propertyName, $"'{ propertyName }' value ({ propertyToTest }) must be a postive integer.");
            }
        }

        public async Task Validate_FkOrgTypeEntity_ExistsInDb(OrgLevelModel entity)
        {
            var propertyName = nameof(entity.OrgTypeId);
            var entityInDb = await _serviceFactory.OrgType.GetAsync(entity.OrgTypeId);

            if (entityInDb is null)
            {
                AddToErrors(propertyName, $"'{ propertyName }' ({entity.OrgTypeId}) not found in database.");
            }
        }

        public async Task Validate_OrgLevelEntity_ExistsInDb(OrgLevelModel entity)
        {
            var propertyName = nameof(entity.Id);
            var entitiesInDb = await _serviceFactory.OrgLevel.GetUntrackedAsync();
            var entityInDb = entitiesInDb.Where(x => x.Id == entity.Id).FirstOrDefault();

            if (entityInDb is null)
            {
                AddToErrors(propertyName, $"'{ propertyName }' not found in database.");
            }
        }
    }
}
