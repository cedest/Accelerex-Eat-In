using Accelerex.Lib.Infrastructure;
using Accelerex.Lib.Models;
using Accelerex.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
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
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string UploadType { get; set; }

            [RequiredWhen("UploadType", "File", AllowEmptyStrings = false, ErrorMessage = "Please upload file (Json string).")]
            public IFormFile OpenHourFile { get; set; }

            [RequiredWhen("UploadType", "Text", AllowEmptyStrings = false, ErrorMessage = "Please paste Json string below")]
            public string OpenHourText { get; set; }

            public OpenHourResponseModel OpenHours { get; set; }
        }

        public OpenHourRequestModel RequestModel { get; set; } = new();

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Input.UploadType == "File")
                    {
                        string ext = Path.GetExtension(Input.OpenHourFile.FileName);
                        bool uploadHasError = ValidateUpload(ext);

                        if (uploadHasError)
                        {
                            return;
                        }

                        Input.OpenHourText = await GetJsonStringFromFile();
                    }

                    RequestModel = ConvertStringToJson(Input.OpenHourText);
                    Input.OpenHours = await _processor.ProcessOpenHour(RequestModel);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
        }

        private bool ValidateUpload(string ext)
        {
            bool error = false;

            if (!IsValidFileType(ext))
            {
                ModelState.AddModelError(string.Empty, "Invalid filetype uploaded. Accepts .txt and .json only");
                error = true;
            }
            if (!IsValidFile())
            {
                ModelState.AddModelError(string.Empty, "Invalid file uploaded");
                error = true;
            }

            return error;
        }

        private bool IsValidFile()
        {
            return (Input.OpenHourFile.Length > 0 && (Input.OpenHourFile.ContentType == "text/plain" || Input.OpenHourFile.ContentType == "application/json"));
        }

        private bool IsValidFileType(string extension)
        {
            return (extension == ".txt" || extension == ".json");
        }

        private async Task<string> GetJsonStringFromFile()
        {
            StringBuilder result = new StringBuilder();
            using (StreamReader reader = new StreamReader(Input.OpenHourFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(await reader.ReadLineAsync());
                }
            }
            return result.ToString();
        }

        private OpenHourRequestModel ConvertStringToJson(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<OpenHourRequestModel>(jsonString);
            }
            catch
            {
                throw;
            }
        }
    }
}
