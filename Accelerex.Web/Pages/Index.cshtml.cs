using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Model;
using Accelerex.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accelerex.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOpenHourProcessor _processor;

        public IndexModel(ILogger<IndexModel> logger,
            IOpenHourProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [BindProperty]
        public bool IsFileUpload { get; set; }

        [BindProperty]
        public bool IsJsonText { get; set; }

        [BindProperty]
        [RequiredWhen("IsFileUpload", false, AllowEmptyStrings = false, ErrorMessage = "A PWR is required if request isn't an Emergency.")]
        public IFormFile OpenHourFile { get; set; }

        [BindProperty]
        [RequiredWhen("IsJsonText", false, AllowEmptyStrings = false, ErrorMessage = "A PWR is required if request isn't an Emergency.")]
        public string OpenHourText { get; set; }

        public OpenHourRequestModel RequestModel { get; set; } = new();

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            string jsonString = JsonConvert.SerializeObject(JObject.Parse(OpenHourText));
            RequestModel = ConvertStringToJson(jsonString);
            var openHours = await _processor.ProcessOpenHour(RequestModel);
        }

        private OpenHourRequestModel ConvertStringToJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<OpenHourRequestModel>(jsonString);
        }
    }
}
