using DacmeOOM.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Commands.OrgLevelCommands
{
    public class DeleteOrgLevelCommand
    {
        public record Command(int Id) : IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _serviceFactory.OrgLevel.GetAsync(request.Id);

                if (entity is null)
                {
                    return false;
                }

                await _serviceFactory.OrgLevel.DeleteAsync(request.Id);

                return true;
            }
        }
    }
}
