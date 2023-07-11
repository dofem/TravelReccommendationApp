using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPredictionApp.Domain.Model;

namespace TravelPredictionApp.Infrastructure.Contract
{
    public interface TravelPredictionInterface
    {
      Task<Recommendation> GenerateTravelRecommendation(string name);
        
    }
}
