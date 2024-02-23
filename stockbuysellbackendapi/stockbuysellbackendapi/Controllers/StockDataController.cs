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
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("crazyfood/{ticker}")]
        [Route("ticker/{ticker}")]
        public async Task<string> GetTicker(string ticker)
        {
            string testUrl = $"This is the test url ticker {ticker}";
            return testUrl;
            string Url = $"insert endpoint here {ticker}";
            var response = await _httpClient.GetAsync(Url);
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