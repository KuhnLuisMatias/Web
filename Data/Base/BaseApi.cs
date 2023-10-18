using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseApi(IHttpClientFactory httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<IActionResult> PostToAPI(string controllerName, object model, string token)
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");
                //En caso de logueo no es necesario null por eso != null
                if(token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer",token);
                }
                var response = await client.PostAsJsonAsync(controllerName, model);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        public async Task<IActionResult> GetToApi(string controllerName, string token)
        {
            try
            {
                var client = _httpClient.CreateClient("useApi");
                var response = await client.GetAsync(controllerName);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                }
                return Unauthorized();
            }
            catch (Exception)
            {
                return Unauthorized();
                throw;
            }
        }
    }
}
