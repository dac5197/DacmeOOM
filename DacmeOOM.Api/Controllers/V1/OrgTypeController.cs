using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Web.Api.Contracts.V1.RequestModels;
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
    public class OrgTypeController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;

        public OrgTypeController(IHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        // GET: api/<OrgTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _handlerFactory.OrgType.GetAsync();
            return Ok(output);
        }

        // GET: api/<OrgTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _handlerFactory.OrgType.GetAsync(id);
            return Ok(output);
        }

        // POST: api/<OrgTypeController>
        [HttpPost]
        public async Task<IActionResult> POST([FromBody] OrgTypeRequestModel value)
        {
            OrgTypeModel orgType = new()
            {
                Name = value.Name
            };

            var output = await _handlerFactory.OrgType.AddAsync(orgType);

            return Ok(output);
        }
    }
}
