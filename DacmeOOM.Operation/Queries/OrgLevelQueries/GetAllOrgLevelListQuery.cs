using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Queries.OrgLevelQueries
{
    public class GetAllOrgLevelListQuery
    {
        public record Query() : IRequest<List<OrgLevelModel>>;

        public class Handler : IRequestHandler<Query, List<OrgLevelModel>>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<List<OrgLevelModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var output = await _serviceFactory.OrgLevel.GetAsync();
                return output;
            }
        }
    }
}
