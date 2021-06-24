using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Queries.OrgTypeQueries
{
    public class GetAllOrgTypeListQuery
    {
        public record Query() : IRequest<List<OrgTypeModel>>;

        public class Handler : IRequestHandler<Query, List<OrgTypeModel>>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<List<OrgTypeModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var output = await _serviceFactory.OrgType.GetAsync();
                return output;
            }
        }
    }
}
