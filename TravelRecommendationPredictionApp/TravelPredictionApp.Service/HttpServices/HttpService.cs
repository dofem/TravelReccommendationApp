using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelPredictionApp.Domain.Model;
using TravelPredictionApp.Service.Dto;
using TravelPredictionApp.Service.Enum;
using TravelPredictionApp.Service.HttpServices.Interface;

namespace TravelPredictionApp.Service.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ApiResponse<T>> MakeHttpRequestAsync<T>(Uri requestUri, string payload, string authToken, AuthType authType, CustomHttpMethod httpMethod) 
        {
            HttpClient httpClient = _clientFactory.CreateClient();

            if (authType == AuthType.Basic)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);
            }
            else if (authType == AuthType.Bearer)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                Method = new HttpMethod(httpMethod.ToString()),
                RequestUri = requestUri,
            };

            if (!string.IsNullOrEmpty(payload))
            {
                StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                httpRequestMessage.Content = content;
            }

            HttpResponseMessage httpResponse = new HttpResponseMessage
            {
                ReasonPhrase = "Network Error",
                StatusCode = System.Net.HttpStatusCode.GatewayTimeout
            };

            string responseString = string.Empty;

            try
            {
                httpResponse = await httpClient.SendAsync(httpRequestMessage);
                responseString = await httpResponse.Content.ReadAsStringAsync();

                httpResponse.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                httpResponse.ReasonPhrase += $"{ex.Message}";
            }

            ApiResponse<T> apiResponse = new ApiResponse<T>
            {
                Success = httpResponse.IsSuccessStatusCode,
                StatusCode = (int)httpResponse.StatusCode,
                Data = default,
                Message = httpResponse.ReasonPhrase ?? ""
            };

            if (httpResponse.IsSuccessStatusCode)
            {
                //if (responseString.StartsWith("["))
                //{

                //    apiResponse.Data = JsonConvert.DeserializeObject<T[]>(responseString).First();
                //}
                //else
                //{
                    apiResponse.Data = JsonConvert.DeserializeObject<T>(responseString);
                //}
            }

            httpResponse.Dispose();
            httpRequestMessage.Dispose();
            httpClient.Dispose();

            return apiResponse;
        }
    }
}

