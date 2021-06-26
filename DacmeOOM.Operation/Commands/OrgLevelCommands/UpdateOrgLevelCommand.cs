using DacmeOOM.Core.Application.Interfaces.IFactories;
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

namespace DacmeOOM.Core.Application.Commands.OrgLevelCommands
{
    public class UpdateOrgLevelCommand
    {
        public record Command(int Id, OrgLevelModel Entity) : IRequest<CommandResponseModel<OrgLevelModel>>;

        public class Handler : IRequestHandler<Command, CommandResponseModel<OrgLevelModel>>
        {
            private readonly IServiceFactory _serviceFactory;
            private readonly IValidatorFactory _validatorFactory;

            public Handler(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
            {
                _serviceFactory = serviceFactory;
                _validatorFactory = validatorFactory;
            }

            public async Task<CommandResponseModel<OrgLevelModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                var errors = await _validatorFactory.OrgLevel.ValidateAsync(request.Entity);

                CommandResponseModel<OrgLevelModel> output = new()
                {
                    Entity = request.Entity
                };

                if (errors.Errors.Any())
                {
                    output.ErrorList = errors;

                    return output;
                }

                await _serviceFactory.OrgLevel.UpdateAsync(request.Entity);

                return output;
            }
        }
    }
}
