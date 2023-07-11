using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPredictionApp.Infrastructure.Contract;
using TravelPredictionApp.Service;
using TravelPredictionApp.Service.HttpServices;
using TravelPredictionApp.Service.HttpServices.Interface;

namespace TravelPredictionApp.Infrastructure
{
    public static class ServiceModule
    {
        public static void AddTravelPredictionService(this IServiceCollection services)
        {
            //Generic repo instantiations
            services.AddScoped<TravelPredictionInterface, TravelPredictionRepository>();
            services.AddHttpServiceConfiguration();
            //services.AddScoped<IHttpService,HttpService>(); 
        }
    }
}
