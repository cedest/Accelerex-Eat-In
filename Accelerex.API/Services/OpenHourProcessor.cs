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

        private string FormatOpenHours<T, U>(List<T> openHours, List<U> nextDayOpenHours)
        {
            var response = new List<string>();

            if (openHours.Count == 0)
                return "Closed";

            if (openHours.Count == 1)
            {
                if (nextDayOpenHours.Count == 0)
                {

                }
            }

            if ((openHours.Count % 2) == 0)
            {

            }

            if ((openHours.Count % 2) == 0)
            {
                for (int i = 0; i < (openHours.Count / 2); i++)
                {
                    var subResponse = new List<string>();

                    var openObj = new
                    {

                    };

                    var b = (T)Activator.CreateInstance(typeof(T));
                    b = openHours[i];
                    var obj = openHours[i];
                    var type = ((dynamic)openHours[i]).Type;
                    var time = ((dynamic)openHours[i]).Value;

                    var subResponseString = string.Join(" - ", subResponse);

                    response.Add(subResponseString);
                }
            }

            return string.Join(", ", response);
        }

        private string ConvertEpochTime(double time)
        {
            string hourSuffix = " PM";
            var conversion = Math.Round((24 * time) / 86400);

            if (conversion > 12)
            {
                conversion -= 12;
                hourSuffix = " PM";
            }

            return $"{conversion}{hourSuffix}";
        }

        private bool ValidateTime<T>(List<T> openHours)
        {
            return false;
        }
    }

    public class DayParam
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
