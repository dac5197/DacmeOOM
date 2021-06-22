using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
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
    public class OrgLevelController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;
        private readonly IMapper _mapper;

        public OrgLevelController(IHandlerFactory handlerFactory, IMapper mapper)
        {
            _handlerFactory = handlerFactory;
            _mapper = mapper;
        }

        // GET: api/<OrgLevelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _handlerFactory.OrgLevel.GetAsync();
            return Ok(output);
        }

        // GET: api/<OrgLevelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _handlerFactory.OrgLevel.GetAsync(id);
            var output = _mapper.EntityModelToResponseModel(entity);
            return Ok(output);
        }

        //POST: api/<OrgLevelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrgLevelRequestModel value)
        {
            //OrgLevelModel orgLevel = new()
            //{
            //    Name = value.Name,
            //    Level = value.Level,
            //    OrgTypeId = value.OrgTypeId
            //};

            var orgLevel = _mapper.RequestModelToEntityModel(value);

            var output = await _handlerFactory.OrgLevel.AddAsync(orgLevel);

            return Ok(output);
        }
    }
}
