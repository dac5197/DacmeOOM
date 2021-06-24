using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Commands.OrgTypeCommands
{
    public class DeleteOrgTypeCommand
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
                var entity = await _serviceFactory.OrgType.GetAsync(request.Id);

                if (entity is null)
                {
                    return false;
                }

                await _serviceFactory.OrgType.DeleteAsync(request.Id);

                return true;
            }
        }
    }
}
