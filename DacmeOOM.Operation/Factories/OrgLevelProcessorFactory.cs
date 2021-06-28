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
        private readonly IValidatorFactory _validatorFactory;
        private IOrgLevelGetAllProcessor _getAll;
        private IOrgLevelGetByIdProcessor _getById;
        private IOrgLevelAddProcessor _add;
        private IOrgLevelUpdateProcessor _update;
        private IOrgLevelDeleteProcessor _delete;

        public OrgLevelProcessorFactory(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
        {
            _serviceFactory = serviceFactory;
            _validatorFactory = validatorFactory;
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

        public IOrgLevelAddProcessor Add
        {
            get
            {
                if (_add is null)
                {
                    _add = new OrgLevelAddProcessor(_serviceFactory, _validatorFactory);
                }

                return _add;
            }
        }

        public IOrgLevelUpdateProcessor Update
        {
            get
            {
                if (_update is null)
                {
                    _update = new OrgLevelUpdateProcessor(_serviceFactory, _validatorFactory);
                }

                return _update;
            }
        }

        public IOrgLevelDeleteProcessor Delete
        {
            get
            {
                if (_delete is null)
                {
                    _delete = new OrgLevelDeleteProcessor(_serviceFactory);
                }

                return _delete;
            }
        }
    }
}
