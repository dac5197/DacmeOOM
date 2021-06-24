using AutoMapper;
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
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrgLevelController(IServiceFactory serviceFactory, IMapper mapper, IMediator mediator)
        {
            _serviceFactory = serviceFactory;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/<OrgLevelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrgLevelListQuery.Query();
            var result = await _mediator.Send(query);
            var output = _mapper.Map<List<OrgLevelResponseModel>>(result);
            return Ok(output);
        }

        // GET: api/<OrgLevelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetOrgLevelByIdQuery.Query(id);
            var result = await _mediator.Send(query);
            var output = _mapper.Map<OrgLevelResponseModel>(result);
            return output is null ? NotFound() : Ok(output);
        }

        //POST: api/<OrgLevelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrgLevelRequestModel value)
        {
            var entity = await _serviceFactory.OrgLevel.AddAsync(_mapper.Map<OrgLevelModel>(value));
            var output = _mapper.Map<OrgLevelResponseModel>(entity);

            return Ok(output);
        }
    }
}
