using DacmeOOM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgLevelController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;

        public OrgLevelController(IHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        // GET: api/<OrgLevelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _handlerFactory.OrgLevels.GetAsync();
            return Ok(output);
        }

        // GET: api/<OrgLevelController>/5
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _handlerFactory.OrgLevels.GetAsync(id);
            return Ok(output);
        }

        ////POST: api/<>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] )
    }
}
