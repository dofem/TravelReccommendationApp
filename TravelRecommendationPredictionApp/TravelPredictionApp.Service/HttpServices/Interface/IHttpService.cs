using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPredictionApp.Service.Dto;
using TravelPredictionApp.Service.Enum;

namespace TravelPredictionApp.Service.HttpServices.Interface
{
    public interface IHttpService
    {
        Task<ApiResponse<T>>  MakeHttpRequestAsync<T>(Uri requestUri, string payload, string authToken, AuthType authType,CustomHttpMethod httpMethod);
    };
}
