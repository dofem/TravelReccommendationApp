using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TravelPredictionApp.Domain.Model;
using TravelPredictionApp.Infrastructure.Utility;
using TravelPredictionApp.Service.Dto;
using TravelPredictionApp.Service.Enum;
using TravelPredictionApp.Service.HttpServices.Interface;

namespace TravelPredictionApp.Infrastructure.Contract
{
    public class TravelPredictionRepository : TravelPredictionInterface
    {
        private readonly ApiSettings _apiSettings;
        private readonly IHttpService _httpService;

        public TravelPredictionRepository(IOptions<ApiSettings> apiSettings,IHttpService httpService)
        {
           _apiSettings = apiSettings.Value;
            _httpService = httpService;
        }


        public Task<Recommendation> GenerateTravelRecommendation(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var tips = GenerateRecommendation(name);

            return tips;
        }



        private async Task<ApiResponse<GenderPredictionResponse>> PredictGender(string name)
        {
            string apiUrl = _apiSettings.GenderizeApiUrl;
            string endpoint = $"{apiUrl}?name={Uri.EscapeDataString(name)}";

            Uri requestUri = new Uri(endpoint);

            ApiResponse<GenderPredictionResponse> response = await _httpService.MakeHttpRequestAsync<GenderPredictionResponse>(requestUri, null,null,AuthType.None, CustomHttpMethod.Get);

            return response;
        }

        private async Task<ApiResponse<CountryPredictionResponse>> PredictNationality(string name)
        {
            string apiUrl = _apiSettings.NationalizeApiUrl;
            string endpoint = $"{apiUrl}?name={Uri.EscapeDataString(name)}";

            Uri requestUri = new Uri(endpoint);

            ApiResponse<CountryPredictionResponse> response = await _httpService.MakeHttpRequestAsync<CountryPredictionResponse>(requestUri, null, null, AuthType.None, CustomHttpMethod.Get);

            return response;
        }


        private async Task<(ICollection<CountryDetails>, double)> FetchCountryDetails(string name)
        {
            string countryId = string.Empty;
            ApiResponse<CountryPredictionResponse> countryPredictionResponse = await PredictNationality(name);
            var countries = countryPredictionResponse.Data.country;
            var highestProbabilityCountry = countries.OrderByDescending(c => c.probability).FirstOrDefault();

            if (highestProbabilityCountry != null)
            {
                countryId = highestProbabilityCountry.country_id;
                double probability = highestProbabilityCountry.probability;
            }

            string apiUrl = _apiSettings.RestCountriesApiUrl;
            string endpoint = $"{apiUrl}?codes={Uri.EscapeDataString(countryId)}";

            Uri requestUri = new Uri(endpoint);

            CountryDetailsResponse countryDetailsResponse = new();
            //countryDetailsResponse.Property1 = 
            var data = (CountryDetails[])JsonConvert.DeserializeObject<ICollection<CountryDetails>>("");
            ApiResponse<ICollection<CountryDetails>> response = await _httpService.MakeHttpRequestAsync<ICollection<CountryDetails>>(requestUri, null, null, AuthType.None, CustomHttpMethod.Get);

            return (response.Data,highestProbabilityCountry.probability);

        }


        public async Task<Recommendation> GenerateRecommendation(string name)
        {
            (ICollection<CountryDetails> countryDetails, double probability) =await FetchCountryDetails(name);
            Recommendation recommendation = new Recommendation();

            foreach (var countryDetail in countryDetails)
            {
                var continent = countryDetail.continents[0];
                var country = countryDetail.name.common;
                var capital = countryDetail.capital[0];
                var currency = countryDetail.currencies;

                if (probability >= 0.4)
                {
                    switch (continent)
                    {
                        case "Africa":
                            recommendation.Tips = $"You have strong connections to {country}, a captivating country in Africa. Don't miss the opportunity to visit {capital}, the heart of {country}. Make sure to immerse yourself in the local culture, taste the traditional cuisine, and explore the breathtaking natural wonders. Don't forget to have some money handy for your adventures!";
                            break;
                        case "Asia":
                            recommendation.Tips = $"Your name is associated with {continent}. It's the largest and most populous continent, home to a rich tapestry of cultures and ancient civilizations. Consider exploring countries like {country} with its iconic landmarks and bustling cities. Immerse yourself in the vibrant street markets, taste the aromatic flavors of local cuisines, and discover the spiritual and historical treasures that await!";
                            break;
                        case "Europe":
                            recommendation.Tips = $"Your name has a European flair to it. Europe is a continent steeped in history and filled with romantic destinations. Plan a journey to countries like {country}, known for their picturesque landscapes, magnificent castles, and world-renowned artworks. Stroll through charming cobblestone streets, indulge in delectable pastries, and immerse yourself in the diverse cultures that thrive in each European nation!";
                            break;
                        case "North America":
                            recommendation.Tips = $"Your name suggests a connection to {continent}. North America is a continent of vast possibilities, from the bustling cities of the United States to the pristine natural wonders of Canada. Consider exploring countries like {country}, where you can experience the vibrant music scene, savor mouthwatering cuisine, and witness the awe-inspiring beauty of iconic landmarks. Get ready for an adventure that will leave lasting memories!";
                            break;
                        case "South America":
                            recommendation.Tips = $"Your name evokes the spirit of {continent}. South America is a continent of vibrant colors, passionate rhythms, and breathtaking landscapes. Plan a journey to countries like {country} to immerse yourself in the energetic rhythms of salsa and samba, explore ancient ruins, and embark on thrilling Amazon rainforest adventures. Get ready to discover the heart and soul of South America!";
                            break;
                        case "Oceania":
                            recommendation.Tips = $"Your name resonates with {continent}. Oceania is a paradise of stunning islands, turquoise waters, and diverse marine life. Consider exploring countries like {country} with its pristine beaches, lush rainforests, and vibrant coral reefs. Dive into the crystal-clear waters, witness unique wildlife, and immerse yourself in the rich indigenous cultures that make Oceania a true tropical haven!";
                            break;
                        // Handle other continents
                        default:
                            recommendation.Tips = $"Your name is associated with {continent}. It's a fascinating continent with its own unique wonders. Consider exploring the countries within {continent} to experience their rich history, culture, and natural beauty.";
                            break;
                    }
                }
                else
                {
                    recommendation.Tips = $"Your name is associated with {continent}. Explore {country} and other countries within {continent} to discover their rich history, culture, and natural beauty. Immerse yourself in the local traditions, try the authentic cuisine, and make unforgettable memories during your journey!";
                }

            }
            //var continent = countryDetails.Property1[0].continents[0].ToString();
            //var country = countryDetails.Property1[0].name.common.ToUpper();
            //var capital = countryDetails.Property1[0].capital.ToString();
            //var currency = countryDetails.Property1[0].currencies.ToString();

            //switch (continent)
            //{
            //    case "Africa":
            //        if (probability >= 0.5)
            //        {
            //            recommendation.Tips = $"You have strong connections to {country}, a captivating country in Africa. Don't miss the opportunity to visit {capital}, the heart of {country}. Make sure to immerse yourself in the local culture, taste the traditional cuisine, and explore the breathtaking natural wonders. Don't forget to have some {currency} handy for your adventures!";
            //        }
            //        else
            //        {
            //            recommendation.Tips = $"Your name has a hint of Africa in it. It's a continent of diverse cultures and fascinating landscapes. Someday, you should plan a trip to explore the vibrant markets, encounter wildlife, and embrace the warm hospitality of the African nations, like {country}. Remember to visit the capital cities and experience the unique charm of each country!";
            //        }
            //        break;
            //    // Handle other continents
            //    default:
            //        recommendation.Tips = $"Your name is associated with {continent}. It's a fascinating continent with its own unique wonders. Consider exploring the countries within {continent} to experience their rich history, culture, and natural beauty.";
            //        break;
            //}

            return recommendation;
        }

        
    }
}
