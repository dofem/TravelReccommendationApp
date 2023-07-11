using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPredictionApp.Domain.Model
{
        public class CountryPredictionResponse
        {
            public Country[] country { get; set; }
            public string name { get; set; }
        }

        public class Country
        {
            public string country_id { get; set; }
            public float probability { get; set; }
        } 
}
