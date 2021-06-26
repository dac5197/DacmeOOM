using AutoMapper;
using DacmeOOM.Core.Application.Commands.OrgLevelCommands;
using DacmeOOM.Core.Application.Interfaces.IFactories;
using DacmeOOM.Core.Application.Queries.OrgLevelQueries;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using DacmeOOM.Web.Api.Maps;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrgLevelController : ControllerBase
    {
        private readonly IProcessorFactory _processorFactory;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrgLevelController(IProcessorFactory processorFactory, IServiceFactory serviceFactory, IMapper mapper, IMediator mediator)
        {
            _processorFactory = processorFactory;
            _serviceFactory = serviceFactory;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<OrgLevelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //// Mediator
            //var query = new GetAllOrgLevelListQuery.Query();
            //var result = await _mediator.Send(query);

            //// Processor
            var result = await _processorFactory.OrgLevel.GetAll.Process();

            var output = _mapper.Map<List<OrgLevelResponseModel>>(result);
            return Ok(output);
        }

        // GET: api/<OrgLevelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //// Mediator
            //var query = new GetOrgLevelByIdQuery.Query(id);
            //var result = await _mediator.Send(query);

            // Processor
            var result = await _processorFactory.OrgLevel.GetById.Process(id);

            var output = _mapper.Map<OrgLevelResponseModel>(result);
            return output is null ? NotFound() : Ok(output);
        }

        // POST: api/<OrgLevelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrgLevelPostRequestModel value)
        {
            var command = new AddOrgLevelCommand.Command(value.Name, value.Level, value.OrgTypeId);
            var result = await _mediator.Send(command);

            if (result.IsValid is false)
            {
                ErrorListReponseModel errorResponse = new();
                errorResponse.SetBadRequest(result.ErrorList.EntityName, _mapper.Map<List<ErrorResponseModel>>(result.ErrorList.Errors));

                return BadRequest(errorResponse);
            }

            var output = _mapper.Map<OrgLevelResponseModel>(result.Entity);

            return Ok(output);
        }

        // PUT: api/<OrgLevelController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrgLevelPutRequestModel value)
        {
            var command = new UpdateOrgLevelCommand.Command(id, _mapper.Map<OrgLevelModel>(value));
            var result = await _mediator.Send(command);

            if (result.IsValid is false)
            {
                ErrorListReponseModel errorResponse = new();
                errorResponse.SetBadRequest(result.ErrorList.EntityName, _mapper.Map<List<ErrorResponseModel>>(result.ErrorList.Errors));

                return BadRequest(errorResponse);
            }

            var output = _mapper.Map<OrgLevelResponseModel>(result.Entity);

            return Ok(output);
        }

        // DELETE: api/<OrgLevelController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrgLevelCommand.Command(id);
            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }
    }
}
