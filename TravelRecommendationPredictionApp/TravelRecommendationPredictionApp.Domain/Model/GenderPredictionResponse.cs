using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPredictionApp.Domain.Model
{
    public class GenderPredictionResponse
    {
        public int count { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public float probability { get; set; }
    }
}
