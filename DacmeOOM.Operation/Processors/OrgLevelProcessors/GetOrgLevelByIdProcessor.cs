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
    public class GetOrgLevelByIdProcessor : IGetOrgLevelByIdProcessor
    {
        private readonly IServiceFactory _serviceFactory;

        public GetOrgLevelByIdProcessor(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<OrgLevelModel> Process(int id)
        {
            var output = await _serviceFactory.OrgLevel.GetAsync(id);
            return output;
        }
    }
}
