using Accelerex.Lib.Models;
using System;
using System.Threading.Tasks;

namespace Accelerex.Lib.Infrastructure
{
    public interface IOpenHourProcessor
    {
        Task<OpenHourResponseModel> ProcessOpenHour(OpenHourRequestModel item);
        Task<OpenHourResponseModel> GetProcessorAsync(Guid id);
        Task<bool> UpdateAsync(OpenHourResponseModel author);
    }
}
