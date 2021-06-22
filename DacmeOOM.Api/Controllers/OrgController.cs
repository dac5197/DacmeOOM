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
    public class OrgController : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;

        public OrgController(IHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        // GET: api/<>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _handlerFactory.OrgLevels.GetAsync();
            return Ok(output);
        }
    }
}
