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
    public class AddOrgTypeCommand
    {
        public record Command(string Name) : IRequest<HandlerModel<OrgTypeModel>>;

        public class Handler : IRequestHandler<Command, HandlerModel<OrgTypeModel>>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public Task<HandlerModel<OrgTypeModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
