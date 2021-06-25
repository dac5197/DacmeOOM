using DacmeOOM.Core.Application.Interfaces;
using DacmeOOM.Core.Application.Validators;
using DacmeOOM.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Factories
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceFactory _serviceFactory;

        private IOrgLevelValidator _orgLevelValidator;
        private IOrgTypeValidator _orgTypeValidator;

        public ValidatorFactory(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public IOrgLevelValidator OrgLevel 
        {
            get
            {
                if (_orgLevelValidator is null)
                {
                    _orgLevelValidator = new OrgLevelValidator(_serviceFactory);
                }

                return _orgLevelValidator;
            }
        }

        public IOrgTypeValidator OrgType
        {
            get
            {
                if (_orgTypeValidator is null)
                {
                    _orgTypeValidator = new OrgTypeValidator(_serviceFactory);
                }

                return _orgTypeValidator;
            }
        }
    }
}
