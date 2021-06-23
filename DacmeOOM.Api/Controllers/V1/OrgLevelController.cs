using AutoMapper;
using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using DacmeOOM.Web.Api.Maps;
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

        public OrgLevelController(IServiceFactory serviceFactory, IMapper mapper)
        {
            _serviceFactory = serviceFactory;
            _mapper = mapper;
        }

        // GET: api/<OrgLevelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _serviceFactory.OrgLevel.GetAsync();
            var output = _mapper.Map<List<OrgLevelResponseModel>>(entities);
            return Ok(output);
        }

        // GET: api/<OrgLevelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _serviceFactory.OrgLevel.GetAsync(id);
            var output = _mapper.Map<OrgLevelResponseModel>(entity);
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
