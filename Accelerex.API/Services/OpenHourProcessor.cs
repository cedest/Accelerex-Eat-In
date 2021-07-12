using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Models;
using System;
using System.Threading.Tasks;

namespace Accelerex.API.Services
{
    public class OpenHourProcessor : IOpenHourProcessor
    {
        public Task<OpenHourResponseModel> GetProcessorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

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

        public Task<bool> UpdateAsync(OpenHourResponseModel author)
        {
            throw new NotImplementedException();
        }
    }
}
