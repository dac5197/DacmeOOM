using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Factories
{
    public class ProcessorFactory : IProcessorFactory
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IValidatorFactory _validatorFactory;
        private IOrgLevelProcessorFactory _orgLevel;

        public ProcessorFactory(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
        {
            _serviceFactory = serviceFactory;
            _validatorFactory = validatorFactory;
        }

        public IOrgLevelProcessorFactory OrgLevel
        {
            get
            {
                if (_orgLevel is null)
                {
                    _orgLevel = new OrgLevelProcessorFactory(_serviceFactory, _validatorFactory);
                }

                return _orgLevel;
            }
        }
    }
}
