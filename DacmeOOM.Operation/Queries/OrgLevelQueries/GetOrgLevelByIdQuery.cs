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
    public class GetOrgLevelByIdQuery
    {
        public record Query(int Id) : IRequest<OrgLevelModel>;

        public class Handler : IRequestHandler<Query, OrgLevelModel>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<OrgLevelModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var output = await _serviceFactory.OrgLevel.GetAsync(request.Id);
                return output;
            }
        }
    }
}
