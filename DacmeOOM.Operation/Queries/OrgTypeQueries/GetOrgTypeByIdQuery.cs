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
    public class GetOrgTypeByIdQuery
    {
        public record Query(int Id) : IRequest<OrgTypeModel>;

        public class Handler : IRequestHandler<Query, OrgTypeModel>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<OrgTypeModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var output = await _serviceFactory.OrgType.GetAsync(request.Id);
                return output;
            }
        }
    }
}
