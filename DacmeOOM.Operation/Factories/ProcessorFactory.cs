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

        private IOrgLevelProcessorFactory _orgLevel;

        public ProcessorFactory(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public IOrgLevelProcessorFactory OrgLevel
        {
            get
            {
                if (_orgLevel is null)
                {
                    _orgLevel = new OrgLevelProcessorFactory(_serviceFactory);
                }

                return _orgLevel;
            }
        }
    }
}
