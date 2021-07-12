using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accelerex.Web.Services
{
    public class OpenHourProcessor : HTTPClientCalls<OpenHourResponseModel, OpenHourProcessor>, IOpenHourProcessor, IDisposable
    {
        public OpenHourProcessor(HttpClient httpClient, IConfiguration configuration)
            : base(httpClient, configuration, "OpenHour", "openhour")
        {
        }

        public async Task<OpenHourResponseModel> ProcessOpenHour(OpenHourRequestModel item)
        {
            return await ProcessItem(item);
        }
    }
}
