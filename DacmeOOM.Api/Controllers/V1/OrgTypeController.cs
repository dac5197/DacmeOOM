using AutoMapper;
using DacmeOOM.Core.Application.Commands.OrgTypeCommands;
using DacmeOOM.Core.Application.Models;
using DacmeOOM.Core.Application.Queries.OrgTypeQueries;
using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
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
    public class OrgTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrgTypeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<OrgTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrgTypeListQuery.Query();
            var result = await _mediator.Send(query);
            var output = _mapper.Map<List<OrgTypeResponseModel>>(result);
            return Ok(output);
        }

        // GET: api/<OrgTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetOrgTypeByIdQuery.Query(id);
            var result = await _mediator.Send(query);
            var output = _mapper.Map<OrgTypeResponseModel>(result);
            return output is null ? NotFound() : Ok(output);
        }

        // POST: api/<OrgTypeController>
        [HttpPost]
        public async Task<IActionResult> POST([FromBody] OrgTypePostRequestModel value)
        {
            var command = new AddOrgTypeCommand.Command(value.Name);
            var result = await _mediator.Send(command);

            if (result.IsValid is false)
            {
                ErrorListReponseModel errorResponse = new();
                errorResponse.SetBadRequest(result.ErrorList.EntityName, _mapper.Map<List<ErrorResponseModel>>(result.ErrorList.Errors));
                
                return BadRequest(errorResponse);
            }

            var output = _mapper.Map<OrgTypeResponseModel>(result.Entity);

            return Ok(output);
        }

        // PUT: api/<OrgTypeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OrgTypePutRequestModel value)
        {
            var command = new UpdateOrgTypeCommand.Command(id, _mapper.Map<OrgTypeModel>(value));
            var result = await _mediator.Send(command);

            if (result.IsValid is false)
            {
                ErrorListReponseModel errorResponse = new();
                errorResponse.SetBadRequest(result.ErrorList.EntityName, _mapper.Map<List<ErrorResponseModel>>(result.ErrorList.Errors));

                return BadRequest(errorResponse);
            }

            var output = _mapper.Map<OrgTypeResponseModel>(result.Entity);

            return Ok(output);
        }

        // DELETE: api/<OrgTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrgTypeCommand.Command(id);
            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }
    }
}
