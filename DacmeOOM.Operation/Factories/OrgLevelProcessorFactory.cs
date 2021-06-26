using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Interfaces.IProcessors;
using DacmeOOM.Core.Application.Processors.OrgLevelProcessors;
using DacmeOOM.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Factories
{
    public class OrgLevelProcessorFactory : IOrgLevelProcessorFactory
    {
        private readonly IServiceFactory _serviceFactory;
        private IOrgLevelGetAllProcessor _getAll;
        private IOrgLevelGetByIdProcessor _getById;

        public OrgLevelProcessorFactory(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public IOrgLevelGetAllProcessor GetAll
        {
            get
            {
                if (_getAll is null)
                {
                    _getAll = new OrgLevelGetAllProcessor(_serviceFactory);
                }

                return _getAll;
            }
        }

        public IOrgLevelGetByIdProcessor GetById
        {
            get
            {
                if (_getById is null)
                {
                    _getById = new OrgLevelGetByIdProcessor(_serviceFactory);
                }

                return _getById;
            }
        }
    }
}
