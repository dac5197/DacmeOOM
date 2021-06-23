using AutoMapper;
using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
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

        public OrgTypeController(IServiceFactory serviceFactory, IMapper mapper)
        {
            _serviceFactory = serviceFactory;
            _mapper = mapper;
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
            return Ok(output);
        }

        // POST: api/<OrgTypeController>
        [HttpPost]
        public async Task<IActionResult> POST([FromBody] OrgTypeRequestModel value)
        {
            var entity = await _serviceFactory.OrgType.AddAsync(_mapper.Map<OrgTypeModel>(value));
            var output = _mapper.Map<OrgTypeResponseModel>(entity);

            return Ok(output);
        }
    }
}
