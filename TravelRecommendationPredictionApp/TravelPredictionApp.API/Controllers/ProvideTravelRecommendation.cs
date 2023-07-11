using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPredictionApp.Infrastructure.Contract;

namespace TravelPredictionApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvideTravelRecommendation : ControllerBase
    {
        private readonly TravelPredictionInterface _travelPredictionInterface;

        public ProvideTravelRecommendation(TravelPredictionInterface travelPredictionInterface)
        {
            _travelPredictionInterface = travelPredictionInterface;
        }

        [HttpGet]
        public async Task<ActionResult> SuggestTravelLocation(string name)
        {
            var tip =await _travelPredictionInterface.GenerateTravelRecommendation(name);
            if(tip == null)
            {
                return NotFound();
            }
            return Ok(tip);
        }
    }
}
