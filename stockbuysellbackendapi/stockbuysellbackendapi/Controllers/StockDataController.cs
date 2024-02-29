using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace AccountOwnerServer.Controllers
{
    [ApiController]

    /*This is the master controller route aka the source to acess this controller if a client types in api/Myass they will get the stockdatacontorller and then we can select what method action we want*/
    [Route("api/[controller]")]
    public class StockDataController : ControllerBase
    {
        private static HttpClient _httpClient;

        public StockDataController()
        {
/*its really that simple dp inject is really just getting an external context and injecting it on instantantion*/
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("GetTicker/{ticker}/{country}")]
        public async Task<string> GetTicker(string ticker, string country)
        {

            string url = $"https://api.agify.io?name={ticker}&country_id={country}";
            var response = await _httpClient.GetAsync(url);
            Response.Headers.Add("Food","Pizza");
            var code = Response.StatusCode;
            Response.Headers.Add("fuckingawesomestatuscode",$"{code}");


            return await response.Content.ReadAsStringAsync();
        }


        /*you must include both the route and the http method otherwise it will thow an exeption*/
        [HttpGet]
        [Route("hello")]
        public string SayHello(){
        return "Hello there darling" ;
        }


        [HttpGet]
        public async Task<string> DoesItKnow(string food)
        {
            string testUrl = $"This is the test url for food {food}";
            return testUrl;
        }


/*There is no need to specify the controller name since we are using a default*/
        [Route("SayGoodbye")]
        public ActionResult<string> SayGoodbye()
        {
            return "Toodaloo!";
        }
    }
}