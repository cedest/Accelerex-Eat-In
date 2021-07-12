using Accelerex.Web.Helpers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Accelerex.Web.Services
{
    public class HTTPClientCalls<T, U> where T : class, new() where U : class, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _objName;
        private readonly string _controllerName;
        private bool _disposed;

        public HTTPClientCalls(HttpClient httpClient, IConfiguration configuration,
            string ObjName, string controllerName)
        {
            _httpClient = httpClient;
            BaseConfiguration = configuration;
            _objName = ObjName;
            _controllerName = controllerName;
        }

        public IConfiguration BaseConfiguration { get; }

        public async Task<T> CreateItem(T item)
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Create {_objName} Method: Disposed");

                HttpResponseMessage result = await _httpClient.PostAsJsonAsync<T>($"api/{_controllerName}", item);
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> ProcessItem<V>(V item) where V : class
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Process {_objName} Method: Disposed");

                HttpResponseMessage result = await _httpClient.PostAsJsonAsync($"api/{_controllerName}", item);
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> DeleteItem(string Id)
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Delete {_objName} Method: Disposed");

                HttpResponseMessage result = await _httpClient.DeleteAsync($"api/{_controllerName}/{Id}");
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }

        public async Task<List<T>> GetAllItem()
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Get {_objName}s Method: Disposed");

                return await _httpClient.GetFromJsonAsync<List<T>>($"api/{_controllerName}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<T>> GetAPIDataByPath(string param, string message, string path)
        {
            try
            {
                await _disposed.CheckDisposed<U>($"{message} Method: Disposed");

                return await _httpClient.GetFromJsonAsync<List<T>>($"api/{_controllerName}/{path}/{param}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetItem(string Id)
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Get {_objName} Method: Disposed");

                HttpResponseMessage result = await _httpClient.GetAsync($"api/{_controllerName}/{Id}");

                return await HelperFunctions.DeserilizeObject<T>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> UpdateItem(string id, T item)
        {
            try
            {
                await _disposed.CheckDisposed<U>($"Update {_objName} Method: Disposed");

                HttpResponseMessage result = await _httpClient.PutAsJsonAsync<T>($"api/{_controllerName}/{((dynamic)item).Id}", item);
                string content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(content);
            }
            catch
            {
                throw;
            }
        }
    }
}
