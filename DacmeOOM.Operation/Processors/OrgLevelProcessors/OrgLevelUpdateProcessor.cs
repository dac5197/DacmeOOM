using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Interfaces.IProcessors;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Processors.OrgLevelProcessors
{
    public class OrgLevelUpdateProcessor : IOrgLevelUpdateProcessor
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly IValidatorFactory _validatorFactory;

        public OrgLevelUpdateProcessor(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
        {
            _serviceFactory = serviceFactory;
            _validatorFactory = validatorFactory;
        }

        public async Task<CommandResponseModel<OrgLevelModel>> ProcessAsync(OrgLevelModel entity)
        {
            var errors = await _validatorFactory.OrgLevel.ValidateAsync(entity);

            CommandResponseModel<OrgLevelModel> output = new()
            {
                Entity = entity
            };

            if (errors.Errors.Any())
            {
                output.ErrorList = errors;

                return output;
            }

            await _serviceFactory.OrgLevel.UpdateAsync(entity);

            return output;
        }
    }
}
