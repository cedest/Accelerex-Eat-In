using Accelerex.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accelerex.Lib.Infrastructure
{
    public interface IOpenHourProcessor
    {
        Task<OpenHourResponseModel> ProcessOpenHour(OpenHourRequestModel item);
    }
}
