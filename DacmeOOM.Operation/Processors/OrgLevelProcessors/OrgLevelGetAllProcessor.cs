using DacmeOOM.Core.Application.Interfaces.IProcessors;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Processors.OrgLevelProcessors
{
    public class OrgLevelGetAllProcessor : IOrgLevelGetAllProcessor
    {
        private readonly IServiceFactory _serviceFactory;

        public OrgLevelGetAllProcessor(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<List<OrgLevelModel>> ProcessAsync()
        {
            var output = await _serviceFactory.OrgLevel.GetAsync();
            return output;
        }
    }
}
