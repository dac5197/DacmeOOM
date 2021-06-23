using DacmeOOM.Application.Models;
using DacmeOOM.Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Validation.Validators
{
    public class OrgLevelValidator : BaseValidator<OrgLevelModel>
    {
        public async Task<List<ErrorModel>> ValidateAsync(OrgLevelModel entity)
        {
            Validate_Name_NotEmpty(entity);

            return await Task.FromResult(Errors);
        }

        private void Validate_Name_NotEmpty(OrgLevelModel entity)
        {
            if (String.IsNullOrEmpty(entity.Name))
            {
                ErrorModel error = new() 
                { 
                    PropertyName = nameof(entity.Name),
                    Message = "Name cannot be null or empty"
                };

                Errors.Add(error);
            }
        }
    }
}
