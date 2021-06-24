using AutoMapper;
using DacmeOOM.Core.Application.Commands.OrgTypeCommands;
using DacmeOOM.Core.Application.Models;
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
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrgTypeController(IServiceFactory serviceFactory, IMapper mapper, IMediator mediator)
        {
            _serviceFactory = serviceFactory;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<OrgTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _serviceFactory.OrgType.GetAsync();
            var output = _mapper.Map<List<OrgTypeResponseModel>>(entities);
            return Ok(output);
        }

        // GET: api/<OrgTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _serviceFactory.OrgType.GetAsync(id);
            var output = _mapper.Map<OrgTypeResponseModel>(entity);
            return output is null ? NotFound() : Ok(output);
        }

        // POST: api/<OrgTypeController>
        [HttpPost]
        public async Task<IActionResult> POST([FromBody] OrgTypeRequestModel value)
        {
            //var entity = await _serviceFactory.OrgType.AddAsync(_mapper.Map<OrgTypeModel>(value));
            //var input = new HandlerModel<OrgTypeModel>()
            //{
            //    Entity = entity
            //};
            var command = new AddOrgTypeCommand.Command(value.Name);
            var result = await _mediator.Send(command);

            if (!result.IsValid)
            {
                return BadRequest(result.ErrorList);
            }

            var output = _mapper.Map<OrgTypeResponseModel>(result.Entity);

            return Ok(output);
        }
    }
}
