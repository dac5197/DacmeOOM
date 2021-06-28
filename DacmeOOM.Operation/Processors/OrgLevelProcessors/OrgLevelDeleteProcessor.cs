using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Interfaces.IProcessors;
using DacmeOOM.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Processors.OrgLevelProcessors
{
    public class OrgLevelDeleteProcessor : IOrgLevelDeleteProcessor
    {
        private readonly IServiceFactory _serviceFactory;

        public OrgLevelDeleteProcessor(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<bool> ProcessAsync(int id)
        {
            //var entity = await _serviceFactory.OrgLevel.GetAsync(id);

            //if (entity is null)
            //{
            //    return false;
            //}

            var output = await _serviceFactory.OrgLevel.DeleteAsync(id);

            return output;
        }
    }
}
