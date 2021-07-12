using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accelerex.Web.Helpers
{
    public static class HelperFunctions
    {
        public static async Task<T> DeserilizeObject<T>(HttpResponseMessage response) where T : class, new()
        {
            string responseData = await response.Content.ReadAsStringAsync();

            if (responseData == "")
            {
                return new T();
            }

            return JsonConvert.DeserializeObject<T>(responseData);
        }

        public static async Task CheckDisposed<T>(this bool isDisposed, string error) where T : class
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(nameof(T));
            }

            await Task.CompletedTask;
        }

        public static string RemoveSpecialCharacters(this string str, string[] rogueChars = null)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new("[ ]{2,}", options);
            str = regex.Replace(str, " ");

            string[] roqueCharacters = { "`", "¬", "|", "!", "\"", "\\", "#", "^", "&", "*", "_", "(", ")", "[", "]", "{", "}", "+", "=", ";", ":", "<", ">", "/", "?", "~" };

            rogueChars ??= roqueCharacters;

            foreach (string rc in rogueChars)
            {
                str = PerformReplace(str, rc, "_");
            }

            return str;
        }

        private static string PerformReplace(string input, string findChar, string replacChar)
        {
            return input.Replace(findChar, replacChar);
        }
    }
}
