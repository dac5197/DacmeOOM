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
        public record Command(string Name) : IRequest<CommandResponseModel<OrgTypeModel>>;

        public class Handler : IRequestHandler<Command, CommandResponseModel<OrgTypeModel>>
        {
            private readonly IServiceFactory _serviceFactory;

            public Handler(IServiceFactory serviceFactory)
            {
                _serviceFactory = serviceFactory;
            }

            public async Task<CommandResponseModel<OrgTypeModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                OrgTypeModel entity = new() { Name = request.Name };

                // TODO: Add validation

                await _serviceFactory.OrgType.AddAsync(entity);

                CommandResponseModel<OrgTypeModel> output = new()
                {
                    Entity = entity
                };

                return output;
            }
        }
    }
}
