namespace TravelPredictionApp.API.MiddleWare
{
     public class ExceptionDetails
    {
        public ExceptionDetails()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}