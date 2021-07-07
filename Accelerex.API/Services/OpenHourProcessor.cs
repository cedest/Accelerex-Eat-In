using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accelerex.API.Services
{
    public class OpenHourProcessor : IOpenHourProcessor
    {
        public async Task<OpenHourResponseModel> ProcessOpenHour(OpenHourRequestModel openHours)
        {
            OpenHourResponseModel response = new();
            response.Monday = Monday.ProcessHours(openHours.Monday, openHours.Tuesday);
            response.Tuesday = Tuesday.ProcessHours(openHours.Tuesday, openHours.Wednesday);
            response.Wednesday = Wednesday.ProcessHours(openHours.Wednesday, openHours.Thursday);
            response.Thursday = Thursday.ProcessHours(openHours.Thursday, openHours.Friday);
            response.Friday = Friday.ProcessHours(openHours.Friday, openHours.Saturday);
            response.Saturday = Saturday.ProcessHours(openHours.Saturday, openHours.Sunday);
            response.Sunday = Sunday.ProcessHours(openHours.Sunday, openHours.Monday);

            return await Task.FromResult(response);
        }
    }
}
