using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        //[HttpPatch("{id:guid}/email")]
        //public async Task<ActionResult> ChangeEmail(Guid id, OpenHourResponseModel model)
        //    => await UpdateNESICTProperty(id, request => request.Monday = model.Monday);

        //private async Task<ActionResult> UpdateNESICTProperty(Guid id, Action<OpenHourResponseModel> action)
        //{
        //    if (await _processor.GetProcessorAsync(id) is not { } author) return BadRequest();

        //    action(author);

        //    bool result = await _processor.UpdateAsync(author);
        //    return result ? Ok() : BadRequest();
        //}
    }
}
