using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPredictionApp.Service.HttpServices;
using TravelPredictionApp.Service.HttpServices.Interface;

namespace TravelPredictionApp.Service
{
    public static class ServiceModule
    {
        public static void AddHttpServiceConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IHttpService, HttpService>();
        }
    }

}
