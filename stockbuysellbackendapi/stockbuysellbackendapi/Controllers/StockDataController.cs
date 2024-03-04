using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Serilog;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    /*This is the master controller route aka the source to acess this controller if a client types in api/Myass they will get the stockdatacontorller and then we can select what method action we want*/
    [Route("api")]
    public class StockDataController : ControllerBase
    {
        private static HttpClient _httpClient;

        public StockDataController()
        {
/*its really that simple dp inject is really just getting an external context and injecting it on instantantion*/
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("stockdata/{ticker}")]
        public async Task<string> GetTicker(string ticker)
        {
            string uri = $"https://api.agify.io?name={ticker}";
            var response = await _httpClient.GetAsync(uri);
            var result = response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();
        }

        /*so really the action here is just sending this data back to the client and they can recieve and parse it as they please*/

        public ActionResult<string> TestThis()
        {
            return "This is a test of the emergency broadcast system";
        }
    }
}