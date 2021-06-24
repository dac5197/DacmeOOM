using DacmeOOM.Core.Application.Interfaces;
using DacmeOOM.Core.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Factories
{
    class ValidatorFactory : IValidatorFactory
    {
        private IOrgTypeValidator _orgTypeValidator;

        public IOrgTypeValidator OrgType
        {
            get
            {
                if (_orgTypeValidator is null)
                {
                    _orgTypeValidator = new OrgTypeValidator();
                }

                return _orgTypeValidator;
            }
        }
    }
}
