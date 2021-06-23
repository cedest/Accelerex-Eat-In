using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accelerex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenHourController : ControllerBase
    {
        private readonly IOpenHourProcessor _processor;

        public OpenHourController(IOpenHourProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public async Task<ActionResult<OpenHourResponseModel>> ProcessOpenHour(OpenHourRequestModel openHourData)
        {
            try
            {
                if (openHourData == null)
                {
                    return BadRequest();
                }

                OpenHourResponseModel createdResponse = await _processor.ProcessOpenHour(openHourData);

                return createdResponse;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Error adding category from databaase");
            }
        }

    }
}
