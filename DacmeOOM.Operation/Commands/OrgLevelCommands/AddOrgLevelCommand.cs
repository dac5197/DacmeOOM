using DacmeOOM.Core.Application.Interfaces;
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
    public class AddOrgLevelCommand
    {
        public record Command(string Name, int Level, int OrgTypeId) : IRequest<CommandResponseModel<OrgLevelModel>>;

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
                OrgLevelModel entity = new()
                {
                    Name = request.Name,
                    Level = request.Level,
                    OrgTypeId = request.OrgTypeId
                };

                var errors = await _validatorFactory.OrgLevel.ValidateAsync(entity);

                CommandResponseModel<OrgLevelModel> output = new()
                {
                    Entity = entity
                };

                if (errors.Errors.Any())
                {
                    output.ErrorList = errors;

                    return output;
                }

                await _serviceFactory.OrgLevel.AddAsync(entity);

                return output;
            }
        }
    }
}
